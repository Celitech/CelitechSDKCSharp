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
/// Service class providing access to API endpoints for DestinationsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class DestinationsService : BaseService
{
    private RequestConfig? _listDestinationsAsyncConfig;

    internal DestinationsService(global::Celitech.SDK.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListDestinationsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public DestinationsService SetListDestinationsAsyncConfig(RequestConfig config)
    {
        _listDestinationsAsyncConfig = config;
        return this;
    }

    /// <summary>List Destinations</summary>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.ListDestinationsResponse> ListDestinationsAsync(
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listDestinationsAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "destinations")
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
        global::Celitech.SDK.ListDestinationsResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.ListDestinationsResponse>(
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
