using Celitech.SDK.Config;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Handlers;
using Celitech.SDK.Http.OAuth;
using Celitech.SDK.Services;

namespace Celitech.SDK;

public partial class CelitechClient : ICelitechClient
{
    private readonly Client _httpClient;
    private readonly Client _tokenHttpClient;

    private readonly TokenManager _tokenManager;

    public IDestinationsClient Destinations { get; }
    public IPackagesClient Packages { get; }
    public IPurchasesClient Purchases { get; }
    public IESimClient ESim { get; }
    public IIFrameClient IFrame { get; }

    public CelitechClient(
        string? clientId = null,
        string? clientSecret = null,
        ClientOptions? clientOptions = null
    )
    {
        clientOptions ??= new ClientOptions();
        var config = new CelitechApiConfig(ClientId: clientId, ClientSecret: clientSecret);
        HttpMessageHandler handler = new ClientOptionsTransport(clientOptions.HttpClient);

        var retryHandler = new RetryHandler(handler, clientOptions.MaxRetries);
        _tokenHttpClient = new Client(
            config,
            handler,
            disposeHandler: handler is null,
            defaultHeaders: clientOptions.AdditionalHeaders
        );
        _tokenManager = new TokenManager(_tokenHttpClient, config);
        var oauthHandler = new OAuthHandler(_tokenManager, retryHandler);
        _httpClient = new Client(
            config,
            oauthHandler,
            disposeHandler: false,
            defaultHeaders: clientOptions.AdditionalHeaders
        );
        var baseUrl = clientOptions.BaseUrl;
        _httpClient.SetBaseAddress(new global::System.Uri(baseUrl).EnsureTrailingSlash());
        _httpClient.SetTimeout(clientOptions.Timeout);
        _tokenHttpClient.SetTimeout(clientOptions.Timeout);

        Destinations = new DestinationsClient(_httpClient);
        Packages = new PackagesClient(_httpClient);
        Purchases = new PurchasesClient(_httpClient);
        ESim = new ESimClient(_httpClient);
        IFrame = new IFrameClient(_httpClient);
    }
}

/// <summary>
/// Bridges Fern's <c>ClientOptions.HttpClient</c> to the legacy delegating-handler transport chain.
/// Each request is dispatched on a fresh clone because the retry handler re-sends the same request
/// object, which the caller's <see cref="HttpClient"/> would otherwise reject as already-sent. This
/// is also the single per-attempt content-cloning site (FSM-1136): retryable content is
/// re-materialized into a fresh buffer on every send so a retried request re-sends its full body,
/// mirroring Fern's <c>RawClient.CloneRequestAsync</c>.
/// </summary>
internal sealed class ClientOptionsTransport : HttpMessageHandler
{
    private readonly HttpClient _inner;

    internal ClientOptionsTransport(HttpClient inner)
    {
        _inner = inner;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        HttpRequestMessage clone;
        if (Core.RetryableRequestContent.IsRetryable(request))
        {
            // Re-materialize retryable content into a fresh buffer per send so a retried attempt
            // re-sends the full body (the original stays re-readable; the sent clone is what the
            // caller's HttpClient consumes/disposes). Mirrors Fern's RawClient.CloneRequestAsync.
            clone = await Core
                .RetryableRequestContent.CloneWithBufferedContentAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            // Non-retryable content (raw streams / multipart with stream parts) can't be re-read, so
            // reuse the original content object and forward it on a fresh envelope: streamed once,
            // never retried (RetryHandler skips the loop for it), preserving streaming semantics.
            clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Version = request.Version,
                Content = request.Content,
            };
            foreach (var header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        return await _inner.SendAsync(clone, cancellationToken).ConfigureAwait(false);
    }
}

// c029837e0e474b76bc487506e8799df5e3335891efe4fb02bda7a1441840310c
