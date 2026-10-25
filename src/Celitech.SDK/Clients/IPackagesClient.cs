using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape interface for PackagesClient. Mirrors the public surface of <c>PackagesClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IPackagesClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IPackagesClient SetConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListPackagesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IPackagesClient SetListPackagesAsyncConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>List Packages</summary>
    WithRawResponseTask<ListPackagesResponse> ListPackagesAsync(
        ListPackagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class PackagesClient : IPackagesClient { }
