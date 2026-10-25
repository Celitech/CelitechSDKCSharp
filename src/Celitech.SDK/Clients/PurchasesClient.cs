using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using Celitech.SDK.Services;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape client for PurchasesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IPurchasesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class PurchasesClient
{
    private readonly PurchasesService _service;

    internal PurchasesClient(global::Celitech.SDK.Http.Client httpClient)
    {
        _service = new PurchasesService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPurchasesClient SetConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreatePurchaseV2Async</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPurchasesClient SetCreatePurchaseV2AsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetCreatePurchaseV2AsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListPurchasesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPurchasesClient SetListPurchasesAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetListPurchasesAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>CreatePurchaseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPurchasesClient SetCreatePurchaseAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetCreatePurchaseAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>TopUpEsimAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPurchasesClient SetTopUpEsimAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetTopUpEsimAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>EditPurchaseAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPurchasesClient SetEditPurchaseAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetEditPurchaseAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetPurchaseConsumptionAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPurchasesClient SetGetPurchaseConsumptionAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetGetPurchaseConsumptionAsyncConfig(config);
        return this;
    }

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public WithRawResponseTask<IEnumerable<CreatePurchaseV2ResponseItem>> CreatePurchaseV2Async(
        CreatePurchaseV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<IEnumerable<CreatePurchaseV2ResponseItem>>(
            WithRawResponseAdapter.WrapEnumerable(
                options,
                () =>
                    _service.CreatePurchaseV2Async(
                        new global::Celitech.SDK.Purchases.CreatePurchaseV2Request
                        {
                            Destination = request.Destination,
                            DataLimitInGb = request.DataLimitInGb,
                            StartDate = request.StartDate,
                            EndDate = request.EndDate,
                            Duration = request.Duration,
                            Quantity = request.Quantity,
                            Email = request.Email,
                            ReferenceId = request.ReferenceId,
                            NetworkBrand = request.NetworkBrand,
                            EmailBrand = request.EmailBrand,
                            Language = request.Language,
                        },
                        request.IdempotencyKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>This endpoint can be used to list all the successful purchases made between a given interval.</summary>
    public WithRawResponseTask<ListPurchasesResponse> ListPurchasesAsync(
        ListPurchasesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ListPurchasesResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListPurchasesAsync(
                        request.PurchaseId,
                        request.Iccid,
                        request.AfterDate,
                        request.BeforeDate,
                        request.Email,
                        request.ReferenceId,
                        request.AfterCursor,
                        request.Limit,
                        request.After,
                        request.Before,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>This endpoint is used to purchase a new eSIM by providing the package details.</summary>
    public WithRawResponseTask<CreatePurchaseResponse> CreatePurchaseAsync(
        CreatePurchaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<CreatePurchaseResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.CreatePurchaseAsync(
                        new global::Celitech.SDK.Purchases.CreatePurchaseRequest
                        {
                            Destination = request.Destination,
                            DataLimitInGb = request.DataLimitInGb,
                            StartDate = request.StartDate,
                            EndDate = request.EndDate,
                            Email = request.Email,
                            ReferenceId = request.ReferenceId,
                            NetworkBrand = request.NetworkBrand,
                            EmailBrand = request.EmailBrand,
                            Language = request.Language,
                            StartTime = request.StartTime,
                            EndTime = request.EndTime,
                        },
                        request.IdempotencyKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>This endpoint is used to top-up an existing eSIM with the previously associated destination by providing its ICCID and package details. To determine if an eSIM can be topped up, use the Get eSIM endpoint, which returns the `isTopUpAllowed` flag.</summary>
    public WithRawResponseTask<TopUpEsimResponse> TopUpEsimAsync(
        TopUpEsimRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TopUpEsimResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.TopUpEsimAsync(
                        new global::Celitech.SDK.Purchases.TopUpEsimRequest
                        {
                            Iccid = request.Iccid,
                            DataLimitInGb = request.DataLimitInGb,
                            StartDate = request.StartDate,
                            EndDate = request.EndDate,
                            Duration = request.Duration,
                            Email = request.Email,
                            ReferenceId = request.ReferenceId,
                            EmailBrand = request.EmailBrand,
                            StartTime = request.StartTime,
                            EndTime = request.EndTime,
                        },
                        request.IdempotencyKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

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
    public WithRawResponseTask<EditPurchaseResponse> EditPurchaseAsync(
        EditPurchaseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<EditPurchaseResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.EditPurchaseAsync(
                        new global::Celitech.SDK.Purchases.EditPurchaseRequest
                        {
                            PurchaseId = request.PurchaseId,
                            StartDate = request.StartDate,
                            EndDate = request.EndDate,
                            StartTime = request.StartTime,
                            EndTime = request.EndTime,
                        },
                        request.IdempotencyKey,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>This endpoint can be called for consumption notifications (e.g. every 1 hour or when the user clicks a button). It returns the data balance (consumption) of purchased packages.</summary>
    public WithRawResponseTask<GetPurchaseConsumptionResponse> GetPurchaseConsumptionAsync(
        GetPurchaseConsumptionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetPurchaseConsumptionResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetPurchaseConsumptionAsync(
                        request.PurchaseId,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
