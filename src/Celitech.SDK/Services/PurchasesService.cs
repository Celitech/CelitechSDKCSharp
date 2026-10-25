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
/// Service class providing access to API endpoints for PurchasesService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class PurchasesService : BaseService
{
    private RequestConfig? _createPurchaseV2AsyncConfig;
    private RequestConfig? _listPurchasesAsyncConfig;
    private RequestConfig? _createPurchaseAsyncConfig;
    private RequestConfig? _topUpEsimAsyncConfig;
    private RequestConfig? _editPurchaseAsyncConfig;
    private RequestConfig? _getPurchaseConsumptionAsyncConfig;

    internal PurchasesService(global::Celitech.SDK.Http.Client httpClient)
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
    /// <param name="idempotencyKey">Optional. A unique value (for example a UUID) that makes this request safe to retry. If a request with the same `Idempotency-Key` and the same body succeeds, repeating it returns the original response instead of performing the action again, and the response includes the header `Idempotent-Replayed: true`. Keys are scoped to your credentials and remembered for 3 days. Only successful (2xx) responses are remembered, so a request that failed can be retried with the same key. Reusing a key with a different request returns `422`; sending it while the original request is still being processed returns `409`. If the idempotency store is temporarily unavailable, the request is not processed and returns `503`; retry it. Must be 1 to 255 printable ASCII characters, without spaces.</param>
    public async global::System.Threading.Tasks.Task<
        List<global::Celitech.SDK.CreatePurchaseV2ResponseItem>
    > CreatePurchaseV2Async(
        global::Celitech.SDK.Purchases.CreatePurchaseV2Request input,
        string? idempotencyKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createPurchaseV2AsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases/v2")
            .SetOptionalHeader("Idempotency-Key", idempotencyKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
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
        List<global::Celitech.SDK.CreatePurchaseV2ResponseItem> result;
        try
        {
            result = global::System.Text.Json.JsonSerializer.Deserialize<
                List<global::Celitech.SDK.CreatePurchaseV2ResponseItem>
            >(responseBody, _jsonSerializerOptions)!;
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
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.ListPurchasesResponse> ListPurchasesAsync(
        string? purchaseId = null,
        string? iccid = null,
        DateOnly? afterDate = null,
        DateOnly? beforeDate = null,
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
        global::Celitech.SDK.ListPurchasesResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.ListPurchasesResponse>(
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

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    /// <param name="idempotencyKey">Optional. A unique value (for example a UUID) that makes this request safe to retry. If a request with the same `Idempotency-Key` and the same body succeeds, repeating it returns the original response instead of performing the action again, and the response includes the header `Idempotent-Replayed: true`. Keys are scoped to your credentials and remembered for 3 days. Only successful (2xx) responses are remembered, so a request that failed can be retried with the same key. Reusing a key with a different request returns `422`; sending it while the original request is still being processed returns `409`. If the idempotency store is temporarily unavailable, the request is not processed and returns `503`; retry it. Must be 1 to 255 printable ASCII characters, without spaces.</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.CreatePurchaseResponse> CreatePurchaseAsync(
        global::Celitech.SDK.Purchases.CreatePurchaseRequest input,
        string? idempotencyKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_createPurchaseAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases")
            .SetOptionalHeader("Idempotency-Key", idempotencyKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
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
        global::Celitech.SDK.CreatePurchaseResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.CreatePurchaseResponse>(
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

    /// <summary>This endpoint is used to top-up an existing eSIM with the previously associated destination by providing its ICCID and package details. To determine if an eSIM can be topped up, use the Get eSIM endpoint, which returns the `isTopUpAllowed` flag.</summary>
    /// <param name="idempotencyKey">Optional. A unique value (for example a UUID) that makes this request safe to retry. If a request with the same `Idempotency-Key` and the same body succeeds, repeating it returns the original response instead of performing the action again, and the response includes the header `Idempotent-Replayed: true`. Keys are scoped to your credentials and remembered for 3 days. Only successful (2xx) responses are remembered, so a request that failed can be retried with the same key. Reusing a key with a different request returns `422`; sending it while the original request is still being processed returns `409`. If the idempotency store is temporarily unavailable, the request is not processed and returns `503`; retry it. Must be 1 to 255 printable ASCII characters, without spaces.</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.TopUpEsimResponse> TopUpEsimAsync(
        global::Celitech.SDK.Purchases.TopUpEsimRequest input,
        string? idempotencyKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_topUpEsimAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases/topup")
            .SetOptionalHeader("Idempotency-Key", idempotencyKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
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
        global::Celitech.SDK.TopUpEsimResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.TopUpEsimResponse>(
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
    /// <param name="idempotencyKey">Optional. A unique value (for example a UUID) that makes this request safe to retry. If a request with the same `Idempotency-Key` and the same body succeeds, repeating it returns the original response instead of performing the action again, and the response includes the header `Idempotent-Replayed: true`. Keys are scoped to your credentials and remembered for 3 days. Only successful (2xx) responses are remembered, so a request that failed can be retried with the same key. Reusing a key with a different request returns `422`; sending it while the original request is still being processed returns `409`. If the idempotency store is temporarily unavailable, the request is not processed and returns `503`; retry it. Must be 1 to 255 printable ASCII characters, without spaces.</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.EditPurchaseResponse> EditPurchaseAsync(
        global::Celitech.SDK.Purchases.EditPurchaseRequest input,
        string? idempotencyKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        var resolvedConfig = GetResolvedConfig(_editPurchaseAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases/edit")
            .SetOptionalHeader("Idempotency-Key", idempotencyKey)
            .SetContentAsJson(input, _jsonSerializerOptions)
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
        global::Celitech.SDK.EditPurchaseResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.EditPurchaseResponse>(
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

    /// <summary>This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.</summary>
    /// <param name="purchaseId">ID of the purchase</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.GetPurchaseConsumptionResponse> GetPurchaseConsumptionAsync(
        string purchaseId,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (purchaseId is null)
            throw new ArgumentNullException(nameof(purchaseId));

        var resolvedConfig = GetResolvedConfig(_getPurchaseConsumptionAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "purchases/{purchaseId}/consumption")
            .SetPathParameter("purchaseId", purchaseId)
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
        global::Celitech.SDK.GetPurchaseConsumptionResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.GetPurchaseConsumptionResponse>(
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
