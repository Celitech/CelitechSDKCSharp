using System.Net.Http.Headers;
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
/// Service class providing access to API endpoints for OAuthService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class OAuthService : BaseService
{
    private RequestConfig? _getAccessTokenAsyncConfig;

    internal OAuthService(global::Celitech.SDK.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetAccessTokenAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public OAuthService SetGetAccessTokenAsyncConfig(RequestConfig config)
    {
        _getAccessTokenAsyncConfig = config;
        return this;
    }

    /// <param name="input">OAuth token request parameters</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.OAuthTokenResponse> GetAccessTokenAsync(
        global::Celitech.SDK.OAuthTokenRequest input,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_getAccessTokenAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "oauth2/token")
            .SetUrlEncodedContent(input, _jsonSerializerOptions)
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
        global::Celitech.SDK.OAuthTokenResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.OAuthTokenResponse>(
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
