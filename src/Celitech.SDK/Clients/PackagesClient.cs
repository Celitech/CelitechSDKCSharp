using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using Celitech.SDK.Services;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape client for PackagesClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IPackagesClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class PackagesClient
{
    private readonly PackagesService _service;

    internal PackagesClient(global::Celitech.SDK.Http.Client httpClient)
    {
        _service = new PackagesService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPackagesClient SetConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>ListPackagesAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IPackagesClient SetListPackagesAsyncConfig(
        global::Celitech.SDK.Config.RequestConfig config
    )
    {
        _service.SetListPackagesAsyncConfig(config);
        return this;
    }

    /// <summary>List Packages</summary>
    public WithRawResponseTask<ListPackagesResponse> ListPackagesAsync(
        ListPackagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<ListPackagesResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () =>
                    _service.ListPackagesAsync(
                        request.Destination,
                        request.DataLimitInGb,
                        request.StartDate,
                        request.EndDate,
                        request.AfterCursor,
                        request.Limit,
                        request.StartTime,
                        request.EndTime,
                        request.IncludeUnlimited,
                        cancellationToken: cancellationToken
                    )
            )
        );
}
