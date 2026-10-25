using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using Celitech.SDK.Services;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape client for DestinationsClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IDestinationsClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class DestinationsClient
{
    private readonly DestinationsService _service;

    internal DestinationsClient(global::Celitech.SDK.Http.Client httpClient)
    {
        _service = new DestinationsService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDestinationsClient SetConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListDestinationsAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IDestinationsClient SetListDestinationsAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetListDestinationsAsyncConfig(config);
        return this;
    }

    /// <summary>List Destinations</summary>
    public WithRawResponseTask<ListDestinationsResponse> ListDestinationsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ListDestinationsResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.ListDestinationsAsync(cancellationToken: cancellationToken)
            )
        );
}
