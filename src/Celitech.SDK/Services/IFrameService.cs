using System.Net.Http.Json;
using Celitech.SDK;
using Celitech.SDK.Config;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Handlers;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Purchases;

namespace Celitech.SDK.Services;

/// <summary>
/// Service class providing access to API endpoints for IFrameService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class IFrameService : BaseService
{
    private RequestConfig? _tokenAsyncConfig;

    internal IFrameService(global::Celitech.SDK.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>TokenAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public IFrameService SetTokenAsyncConfig(RequestConfig config)
    {
        _tokenAsyncConfig = config;
        return this;
    }

    /// <summary>Generate a new token to be used in the iFrame</summary>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.TokenResponse> TokenAsync(
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_tokenAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "iframe/token")
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::Celitech.SDK.TokenResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.TokenResponse>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new Celitech.SDK.CelitechClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: Celitech.SDK.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }
}
