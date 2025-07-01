using System.Net.Http.Json;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Models;
using Celitech.SDK.Validation;
using Celitech.SDK.Validation.Extensions;

namespace Celitech.SDK.Services;

public class PackagesService : BaseService
{
    internal PackagesService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>List Packages</summary>
    /// <param name="destination">ISO representation of the package's destination.</param>
    /// <param name="startDate">Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.</param>
    /// <param name="endDate">End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.</param>
    /// <param name="afterCursor">To get the next batch of results, use this parameter. It tells the API where to start fetching data after the last item you received. It helps you avoid repeats and efficiently browse through large sets of data.</param>
    /// <param name="limit">Maximum number of packages to be returned in the response. The value must be greater than 0 and less than or equal to 160. If not provided, the default value is 20</param>
    /// <param name="startTime">Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months</param>
    /// <param name="endTime">Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time</param>
    /// <param name="duration">Duration in seconds for the package's validity. If this parameter is present, it will override the startTime and endTime parameters. The maximum duration for a package's validity period is 90 days</param>
    public async Task<ListPackagesOkResponse> ListPackagesAsync(
        string? destination = null,
        string? startDate = null,
        string? endDate = null,
        string? afterCursor = null,
        double? limit = null,
        long? startTime = null,
        long? endTime = null,
        double? duration = null,
        CancellationToken cancellationToken = default
    )
    {
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "packages")
            .SetOptionalQueryParameter("destination", destination)
            .SetOptionalQueryParameter("startDate", startDate)
            .SetOptionalQueryParameter("endDate", endDate)
            .SetOptionalQueryParameter("afterCursor", afterCursor)
            .SetOptionalQueryParameter("limit", limit)
            .SetOptionalQueryParameter("startTime", startTime)
            .SetOptionalQueryParameter("endTime", endTime)
            .SetOptionalQueryParameter("duration", duration)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<ListPackagesOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
