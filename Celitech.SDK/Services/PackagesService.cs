using System.Net.Http.Json;
using Celitech.SDK.Config;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Handlers;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Validation;
using Celitech.SDK.Validation.Extensions;

namespace Celitech.SDK.Services;

/// <summary>
/// Service class providing access to API endpoints for PackagesService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class PackagesService : BaseService
{
    private RequestConfig? _listPackagesAsyncConfig;

    internal PackagesService(Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListPackagesAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public PackagesService SetListPackagesAsyncConfig(RequestConfig config)
    {
        _listPackagesAsyncConfig = config;
        return this;
    }

    /// <summary>List Packages</summary>
    /// <param name="destination">ISO representation of the package's destination. Supports both ISO2 (e.g., 'FR') and ISO3 (e.g., 'FRA') country codes.</param>
    /// <param name="startDate">Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.</param>
    /// <param name="endDate">End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.</param>
    /// <param name="afterCursor">To get the next batch of results, use this parameter. It tells the API where to start fetching data after the last item you received. It helps you avoid repeats and efficiently browse through large sets of data.</param>
    /// <param name="limit">Maximum number of packages to be returned in the response. The value must be greater than 0 and less than or equal to 160. If not provided, the default value is 20</param>
    /// <param name="startTime">Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months</param>
    /// <param name="endTime">Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time</param>
    public async Task<object> ListPackagesAsync(
        string? accept,
        string? destination = null,
        string? startDate = null,
        string? endDate = null,
        string? afterCursor = null,
        string? limit = null,
        string? startTime = null,
        string? endTime = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var acceptValidationResult = new StringValidator().ValidateRequired<string>(accept);
        if (acceptValidationResult != null)
        {
            validationResults.Add(acceptValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_listPackagesAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "packages")
            .SetHeader("Accept", accept)
            .SetQueryParameter("destination", destination)
            .SetQueryParameter("startDate", startDate)
            .SetQueryParameter("endDate", endDate)
            .SetQueryParameter("afterCursor", afterCursor)
            .SetQueryParameter("limit", limit)
            .SetQueryParameter("startTime", startTime)
            .SetQueryParameter("endTime", endTime)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result = DeserializationValidation.DeserializeWithRequiredFieldValidation<object>(
            jsonContent,
            _jsonSerializerOptions
        );

        // Validate the response
        // Skip validation for primitive types or OneOf types

        return result;
    }
}
