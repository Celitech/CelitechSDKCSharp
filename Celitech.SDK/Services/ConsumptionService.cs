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
/// Service class providing access to API endpoints for ConsumptionService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class ConsumptionService : BaseService
{
    private RequestConfig? _getPurchaseConsumptionAsyncConfig;

    internal ConsumptionService(Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetPurchaseConsumptionAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ConsumptionService SetGetPurchaseConsumptionAsyncConfig(RequestConfig config)
    {
        _getPurchaseConsumptionAsyncConfig = config;
        return this;
    }

    /// <summary>This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.</summary>
    public async Task<object> GetPurchaseConsumptionAsync(
        string purchaseId,
        string? accept,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(purchaseId, nameof(purchaseId));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var purchaseIdValidationResult = new StringValidator().ValidateRequired<string>(purchaseId);
        if (purchaseIdValidationResult != null)
        {
            validationResults.Add(purchaseIdValidationResult);
        }
        ;
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

        var resolvedConfig = GetResolvedConfig(_getPurchaseConsumptionAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "purchases/{purchaseId}/consumption")
            .SetPathParameter("purchaseId", purchaseId)
            .SetHeader("Accept", accept)
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
