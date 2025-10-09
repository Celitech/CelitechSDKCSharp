using System.Net.Http.Json;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Models;
using Celitech.SDK.Validation;
using Celitech.SDK.Validation.Extensions;

namespace Celitech.SDK.Services;

public class PurchasesService : BaseService
{
    internal PurchasesService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public async Task<List<CreatePurchaseV2OkResponse>> CreatePurchaseV2Async(
        CreatePurchaseV2Request input,
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

        var request = new RequestBuilder(HttpMethod.Post, "purchases/v2")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        var result =
            await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<List<CreatePurchaseV2OkResponse>>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");

        return result;
    }

    /// <summary>This endpoint can be used to list all the successful purchases made between a given interval.</summary>
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
        string? iccid = null,
        string? afterDate = null,
        string? beforeDate = null,
        string? email = null,
        string? referenceId = null,
        string? afterCursor = null,
        double? limit = null,
        double? after = null,
        double? before = null,
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

        var request = new RequestBuilder(HttpMethod.Get, "purchases")
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
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        var result =
            await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<ListPurchasesOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");

        return result;
    }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public async Task<CreatePurchaseOkResponse> CreatePurchaseAsync(
        CreatePurchaseRequest input,
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

        var request = new RequestBuilder(HttpMethod.Post, "purchases")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        var result =
            await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<CreatePurchaseOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");

        return result;
    }

    /// <summary>This endpoint is used to top-up an existing eSIM with the previously associated destination by providing its ICCID and package details. To determine if an eSIM can be topped up, use the Get eSIM Status endpoint, which returns the `isTopUpAllowed` flag.</summary>
    public async Task<TopUpEsimOkResponse> TopUpEsimAsync(
        TopUpEsimRequest input,
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

        var request = new RequestBuilder(HttpMethod.Post, "purchases/topup")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        var result =
            await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<TopUpEsimOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");

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

        var request = new RequestBuilder(HttpMethod.Post, "purchases/edit")
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        var result =
            await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<EditPurchaseOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");

        return result;
    }

    /// <summary>This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.</summary>
    /// <param name="purchaseId">ID of the purchase</param>
    public async Task<GetPurchaseConsumptionOkResponse> GetPurchaseConsumptionAsync(
        string purchaseId,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(purchaseId, nameof(purchaseId));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var purchaseIdValidationResult = new StringValidator().ValidateRequired<string?>(
            (string?)purchaseId
        );
        if (purchaseIdValidationResult != null)
        {
            validationResults.Add(purchaseIdValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "purchases/{purchaseId}/consumption")
            .SetPathParameter("purchaseId", purchaseId)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        var result =
            await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetPurchaseConsumptionOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");

        return result;
    }
}
