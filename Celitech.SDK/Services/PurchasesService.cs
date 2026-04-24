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
    private RequestConfig? _createPurchaseV2AsyncConfig;
    private RequestConfig? _listPurchasesAsyncConfig;
    private RequestConfig? _createPurchaseAsyncConfig;
    private RequestConfig? _topUpEsimAsyncConfig;
    private RequestConfig? _editPurchaseAsyncConfig;
    private RequestConfig? _getPurchaseConsumptionAsyncConfig;

    internal PurchasesService(Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>CreatePurchaseV2Async</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public PurchasesService SetCreatePurchaseV2AsyncConfig(RequestConfig config)
    {
        _createPurchaseV2AsyncConfig = config;
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
    /// Sets method-level configuration for <c>TopUpEsimAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public PurchasesService SetTopUpEsimAsyncConfig(RequestConfig config)
    {
        _topUpEsimAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>EditPurchaseAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public PurchasesService SetEditPurchaseAsyncConfig(RequestConfig config)
    {
        _editPurchaseAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetPurchaseConsumptionAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public PurchasesService SetGetPurchaseConsumptionAsyncConfig(RequestConfig config)
    {
        _getPurchaseConsumptionAsyncConfig = config;
        return this;
    }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public async Task<List<CreatePurchaseV2OkResponse>> CreatePurchaseV2Async(
        CreatePurchaseV2Request input,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var validator = new CreatePurchaseV2RequestValidator();
        var validationResult = validator.Validate(input);
        validationResults.Add(validationResult);

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_createPurchaseV2AsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases/v2")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .AddError(400, "application/json", typeof(BadRequest), typeof(BadRequestException))
            .AddError(401, "application/json", typeof(Unauthorized), typeof(UnauthorizedException))
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result = DeserializationValidation.DeserializeWithRequiredFieldValidation<
            List<CreatePurchaseV2OkResponse>
        >(jsonContent, _jsonSerializerOptions);

        // Validate the response
        var responseValidator = new ListValidator<CreatePurchaseV2OkResponse>();
        var responseValidationResult = responseValidator.ValidateRequiredList(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }
        var itemFailures = new List<FluentValidation.Results.ValidationFailure>();
        var itemValidator = new CreatePurchaseV2OkResponseValidator();
        foreach (var item in result)
        {
            var itemResult = itemValidator.Validate(item);
            if (!itemResult.IsValid)
                itemFailures.AddRange(itemResult.Errors);
        }
        if (itemFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(itemFailures);
        }

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
    public async Task<ListPurchasesOkResponse> ListPurchasesAsync(
        string? purchaseId = null,
        string? iccid = null,
        string? afterDate = null,
        string? beforeDate = null,
        string? email = null,
        string? referenceId = null,
        string? afterCursor = null,
        double? limit = null,
        double? after = null,
        double? before = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateOptional<string?>((string?)iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_listPurchasesAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "purchases")
            .SetOptionalQueryParameter("purchaseId", purchaseId)
            .SetOptionalQueryParameter("iccid", iccid)
            .SetOptionalQueryParameter("afterDate", afterDate)
            .SetOptionalQueryParameter("beforeDate", beforeDate)
            .SetOptionalQueryParameter("email", email)
            .SetOptionalQueryParameter("referenceId", referenceId)
            .SetOptionalQueryParameter("afterCursor", afterCursor)
            .SetOptionalQueryParameter("limit", limit)
            .SetOptionalQueryParameter("after", after)
            .SetOptionalQueryParameter("before", before)
            .SetScopes(new HashSet<string> { })
            .AddError(400, "application/json", typeof(BadRequest), typeof(BadRequestException))
            .AddError(401, "application/json", typeof(Unauthorized), typeof(UnauthorizedException))
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result =
            DeserializationValidation.DeserializeWithRequiredFieldValidation<ListPurchasesOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new ListPurchasesOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public async Task<CreatePurchaseOkResponse> CreatePurchaseAsync(
        CreatePurchaseRequest input,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
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
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .AddError(400, "application/json", typeof(BadRequest), typeof(BadRequestException))
            .AddError(401, "application/json", typeof(Unauthorized), typeof(UnauthorizedException))
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result =
            DeserializationValidation.DeserializeWithRequiredFieldValidation<CreatePurchaseOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new CreatePurchaseOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }

    /// <summary>This endpoint is used to top-up an existing eSIM with the previously associated destination by providing its ICCID and package details. To determine if an eSIM can be topped up, use the Get eSIM endpoint, which returns the `isTopUpAllowed` flag.</summary>
    public async Task<TopUpEsimOkResponse> TopUpEsimAsync(
        TopUpEsimRequest input,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var validator = new TopUpEsimRequestValidator();
        var validationResult = validator.Validate(input);
        validationResults.Add(validationResult);

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_topUpEsimAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases/topup")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .AddError(400, "application/json", typeof(BadRequest), typeof(BadRequestException))
            .AddError(401, "application/json", typeof(Unauthorized), typeof(UnauthorizedException))
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result =
            DeserializationValidation.DeserializeWithRequiredFieldValidation<TopUpEsimOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new TopUpEsimOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }

    /// <summary>
    /// This endpoint allows you to modify the validity dates of an existing purchase.
    ///
    /// **Behavior:**
    /// - If the purchase has **not yet been activated**, both the start and end dates can be updated.
    /// - If the purchase is **already active**, only the **end date** can be updated, while the **start date must remain unchanged** (and should be passed as originally set).
    /// - Updates must comply with the same pricing structure; the modification cannot alter the package size or change its duration category.
    ///
    /// The end date can be extended or shortened as long as it adheres to the same pricing category and does not exceed the allowed duration limits.
    /// </summary>
    public async Task<EditPurchaseOkResponse> EditPurchaseAsync(
        EditPurchaseRequest input,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var validator = new EditPurchaseRequestValidator();
        var validationResult = validator.Validate(input);
        validationResults.Add(validationResult);

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_editPurchaseAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases/edit")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .AddError(400, "application/json", typeof(BadRequest), typeof(BadRequestException))
            .AddError(401, "application/json", typeof(Unauthorized), typeof(UnauthorizedException))
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result =
            DeserializationValidation.DeserializeWithRequiredFieldValidation<EditPurchaseOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new EditPurchaseOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }

    /// <summary>This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.</summary>
    /// <param name="purchaseId">ID of the purchase</param>
    public async Task<GetPurchaseConsumptionOkResponse> GetPurchaseConsumptionAsync(
        string purchaseId,
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

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_getPurchaseConsumptionAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "purchases/{purchaseId}/consumption")
            .SetPathParameter("purchaseId", purchaseId)
            .SetScopes(new HashSet<string> { })
            .AddError(400, "application/json", typeof(BadRequest), typeof(BadRequestException))
            .AddError(401, "application/json", typeof(Unauthorized), typeof(UnauthorizedException))
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result =
            DeserializationValidation.DeserializeWithRequiredFieldValidation<GetPurchaseConsumptionOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new GetPurchaseConsumptionOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }
}
