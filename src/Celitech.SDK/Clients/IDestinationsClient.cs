using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape interface for DestinationsClient. Mirrors the public surface of <c>DestinationsClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IDestinationsClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IDestinationsClient SetConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>ListDestinationsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IDestinationsClient SetListDestinationsAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    );

    /// <summary>List Destinations</summary>
    WithRawResponseTask<ListDestinationsResponse> ListDestinationsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class DestinationsClient : IDestinationsClient { }
