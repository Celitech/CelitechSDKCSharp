using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using Celitech.SDK.Services;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape client for ESimClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IESimClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class ESimClient
{
    private readonly ESimService _service;

    internal ESimClient(global::Celitech.SDK.Http.Client httpClient)
    {
        _service = new ESimService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IESimClient SetConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IESimClient SetGetEsimAsyncConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetGetEsimAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimDeviceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IESimClient SetGetEsimDeviceAsyncConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetGetEsimDeviceAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimHistoryAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IESimClient SetGetEsimHistoryAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetGetEsimHistoryAsyncConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SuspendEsimAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IESimClient SetSuspendEsimAsyncConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetSuspendEsimAsyncConfig(config);
        return this;
    }

    /// <summary>Get eSIM</summary>
    public WithRawResponseTask<GetEsimResponse> GetEsimAsync(
        GetEsimRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetEsimResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.GetEsimAsync(request.Iccid, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Get eSIM Device</summary>
    public WithRawResponseTask<GetEsimDeviceResponse> GetEsimDeviceAsync(
        GetEsimDeviceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetEsimDeviceResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetEsimDeviceAsync(request.Iccid, cancellationToken: cancellationToken)
            )
        );

    /// <summary>Get eSIM History</summary>
    public WithRawResponseTask<GetEsimHistoryResponse> GetEsimHistoryAsync(
        GetEsimHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<GetEsimHistoryResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.GetEsimHistoryAsync(
                        request.Iccid,
                        cancellationToken: cancellationToken
                    )
            )
        );

    /// <summary>Suspends an eSIM to prevent abuse. All of the eSIM's packages are terminated and its connectivity is switched off. The eSIM is not refunded: the charge stays.</summary>
    public WithRawResponseTask<SuspendEsimResponse> SuspendEsimAsync(
        SuspendEsimRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<SuspendEsimResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.SuspendEsimAsync(
                        request.Iccid,
                        request.IdempotencyKey,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
