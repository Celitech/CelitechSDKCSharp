using System.Net.Http.Json;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Handlers;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Models;
using Celitech.SDK.Validation;
using Celitech.SDK.Validation.Extensions;

namespace Celitech.SDK.Services;

/// <summary>
/// Service class providing access to API endpoints for DestinationsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class DestinationsService : BaseService
{
    internal DestinationsService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>List Destinations</summary>
    public async Task<ListDestinationsOkResponse> ListDestinationsAsync(
        CancellationToken cancellationToken = default
    )
    {
        var request = new RequestBuilder(HttpMethod.Get, "destinations")
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        var responseContent = response.EnsureSuccessfulResponse().Content;
        var contentLength = responseContent.Headers.ContentLength;

        ListDestinationsOkResponse result;
        if (contentLength == null || contentLength > 0)
        {
            result =
                await responseContent
                    .ReadFromJsonAsync<ListDestinationsOkResponse>(
                        _jsonSerializerOptions,
                        cancellationToken
                    )
                    .ConfigureAwait(false)
                ?? throw new Exception("Failed to deserialize response.");
        }
        else
        {
            // Empty response body - return default instance
            result = default!;
        }

        return result;
    }
}
