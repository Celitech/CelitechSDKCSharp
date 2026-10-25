using System.Net.Http.Headers;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.OAuth;

namespace Celitech.SDK.Http.Handlers;

/// <summary>
/// A handler for executing OAuth requests.
/// </summary>
public class OAuthHandler : DelegatingHandler
{
    private TokenManager tokenManager;

    /// <summary>
    /// A caller-supplied access token, when the client was constructed with one.
    /// </summary>
    /// <remarks>
    /// Its presence suppresses OAuth acquisition entirely: the inner token handler stamps this
    /// credential onto the request, so fetching a second one would be wasted at best and fatal at
    /// worst -- an API that also declares client-credentials has no client id to fetch WITH when the
    /// caller authenticated by token, and the request died with "ClientId is required" before
    /// reaching the wire (FSDK-2217).
    /// </remarks>
    private readonly string? staticAccessToken;

    internal OAuthHandler(
        TokenManager tokenManager,
        HttpMessageHandler? innerHandler = null,
        string? staticAccessToken = null
    )
        : base(innerHandler ?? Client.CreateDefaultTransport())
    {
        this.tokenManager = tokenManager;
        this.staticAccessToken = staticAccessToken;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        await GetTokenAsync(request, cancellationToken);

        return await base.SendAsync(request, cancellationToken);
    }

    private async global::System.Threading.Tasks.Task GetTokenAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var scopes = request.GetScopes();
            if (
                scopes is not null
                && !IsPerCallOverride(request, "Authorization")
                && string.IsNullOrEmpty(this.staticAccessToken)
            )
            {
                var token = await this.tokenManager.GetTokenAsync(scopes, cancellationToken);
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token.AccessToken
                );
            }
        }
        // A cancelled request throws OperationCanceledException, which is not an auth failure.
        // Cleaning here would wipe the shared cached token for every other in-flight caller, so
        // let cancellation propagate untouched and only Clean() on genuine auth errors.
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            this.tokenManager.Clean();
            throw;
        }
    }

    /// <summary>
    /// Whether the caller supplied <c>Authorization</c> for this one call via
    /// <c>RequestOptions.AdditionalHeaders</c>. Those are documented to overwrite any spec/auth
    /// header with a matching key, but <c>RequestOptionsMerger</c> applies them while the request is
    /// still being built and this handler runs afterwards, so assigning
    /// <c>request.Headers.Authorization</c> here would silently discard a per-call credential
    /// override (FSDK-1674, the OAuth half of FSDK-1588). The recorded set is case-insensitive,
    /// matching <c>HttpHeaders</c>; that holds because
    /// <c>RequestOptionsMerger.ApplyAdditionalHeaders</c> is its only producer and always builds it
    /// with <c>StringComparer.OrdinalIgnoreCase</c>. The pre-NET5 branch recovers it from
    /// <c>request.Properties</c> as an <c>object</c> and so cannot re-check the comparer. A request
    /// that never went through the merger carries no entry at all and reports <c>false</c>.
    /// </summary>
    /// <remarks>
    /// Unlike the static credential the other handlers hold, this token is scope-derived, so
    /// standing down means more than not writing a header: no token is requested. That is
    /// deliberate. Acquiring one would spend a call on the token endpoint for a credential that is
    /// about to be discarded; worse, <c>TokenManager.GetTokenAsync</c> accumulates scopes onto the
    /// shared cached token and <c>Clean()</c>s it on failure, so a request that does not even use
    /// the token could reshape or invalidate the cache for the ones that do -- and a token-endpoint
    /// failure would fail a request the caller had already supplied a credential for. The SDK also
    /// cannot reason about the scopes of an opaque caller-supplied bearer; the server is the only
    /// authority on whether it covers the operation, and it answers with 401/403.
    /// </remarks>
    private static bool IsPerCallOverride(HttpRequestMessage request, string header)
    {
#if NET5_0_OR_GREATER
        return request.Options.TryGetValue(
                new HttpRequestOptionsKey<HashSet<string>>(
                    Celitech.SDK.Core.RequestOptionsMerger.PerCallHeaderKeysKey
                ),
                out var keys
            ) && keys.Contains(header);
#else
        return request.Properties.TryGetValue(
                Celitech.SDK.Core.RequestOptionsMerger.PerCallHeaderKeysKey,
                out var _keysObj
            )
            && _keysObj is HashSet<string> keys
            && keys.Contains(header);
#endif
    }
}
