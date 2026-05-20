using System.Net.Http.Json;
using Celitech.SDK.Config;
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
/// Service class providing access to API endpoints for PurchasesService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class PurchasesService : BaseService
{
    private RequestConfig? _createPurchaseAsyncConfig;
    private RequestConfig? _listPurchasesAsyncConfig;

    internal PurchasesService(Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>CreatePurchaseAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public PurchasesService SetCreatePurchaseAsyncConfig(RequestConfig config)
    {
        _createPurchaseAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListPurchasesAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public PurchasesService SetListPurchasesAsyncConfig(RequestConfig config)
    {
        _listPurchasesAsyncConfig = config;
        return this;
    }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public async Task<object> CreatePurchaseAsync(
        CreatePurchaseRequest? input,
        string? accept,
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
        ;
        var validator = new CreatePurchaseRequestValidator();
        var validationResult = validator.Validate(input);
        validationResults.Add(validationResult);

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_createPurchaseAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases")
            .SetHeader("Accept", accept)
            .SetContentAsJson(input, _jsonSerializerOptions)
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

    /// <summary>This endpoint can be used to list all the successful purchases made between a given interval.</summary>
    /// <param name="purchaseId">ID of the purchase</param>
    /// <param name="iccid">ID of the eSIM</param>
    /// <param name="afterDate">Start date of the interval for filtering purchases in the format 'yyyy-MM-dd'</param>
    /// <param name="beforeDate">End date of the interval for filtering purchases in the format 'yyyy-MM-dd'</param>
    /// <param name="email">Email associated to the purchase.</param>
    /// <param name="referenceId">The referenceId that was provided by the partner during the purchase or topup flow.</param>
    /// <param name="afterCursor">To get the next batch of results, use this parameter. It tells the API where to start fetching data after the last item you received. It helps you avoid repeats and efficiently browse through large sets of data.</param>
    /// <param name="limit">Maximum number of purchases to be returned in the response. The value must be greater than 0 and less than or equal to 100. If not provided, the default value is 20</param>
    /// <param name="after">Epoch value representing the start of the time interval for filtering purchases</param>
    /// <param name="before">Epoch value representing the end of the time interval for filtering purchases</param>
    public async Task<object> ListPurchasesAsync(
        string? accept,
        string? purchaseId = null,
        string? iccid = null,
        string? afterDate = null,
        string? beforeDate = null,
        string? email = null,
        string? referenceId = null,
        string? afterCursor = null,
        string? limit = null,
        string? after = null,
        string? before = null,
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

        var resolvedConfig = GetResolvedConfig(_listPurchasesAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "purchases")
            .SetHeader("Accept", accept)
            .SetQueryParameter("purchaseId", purchaseId)
            .SetQueryParameter("iccid", iccid)
            .SetQueryParameter("afterDate", afterDate)
            .SetQueryParameter("beforeDate", beforeDate)
            .SetQueryParameter("email", email)
            .SetQueryParameter("referenceId", referenceId)
            .SetQueryParameter("afterCursor", afterCursor)
            .SetQueryParameter("limit", limit)
            .SetQueryParameter("after", after)
            .SetQueryParameter("before", before)
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
