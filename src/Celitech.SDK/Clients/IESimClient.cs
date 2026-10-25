using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape interface for ESimClient. Mirrors the public surface of <c>ESimClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IESimClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IESimClient SetConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IESimClient SetGetEsimAsyncConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimDeviceAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IESimClient SetGetEsimDeviceAsyncConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimHistoryAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IESimClient SetGetEsimHistoryAsyncConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>SuspendEsimAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IESimClient SetSuspendEsimAsyncConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>Get eSIM</summary>
    WithRawResponseTask<GetEsimResponse> GetEsimAsync(
        GetEsimRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get eSIM Device</summary>
    WithRawResponseTask<GetEsimDeviceResponse> GetEsimDeviceAsync(
        GetEsimDeviceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Get eSIM History</summary>
    WithRawResponseTask<GetEsimHistoryResponse> GetEsimHistoryAsync(
        GetEsimHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>Suspends an eSIM to prevent abuse. All of the eSIM's packages are terminated and its connectivity is switched off. The eSIM is not refunded: the charge stays.</summary>
    WithRawResponseTask<SuspendEsimResponse> SuspendEsimAsync(
        SuspendEsimRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class ESimClient : IESimClient { }
