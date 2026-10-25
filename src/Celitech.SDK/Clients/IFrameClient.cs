using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using Celitech.SDK.Services;
using global::System.Linq;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape client for IFrameClient. Public surface mirrors Fern; execution delegates to the
/// internal legacy service runtime. Declared <c>partial</c> so the interface base
/// (<c>IIFrameClient</c>, FSM-144) can be added in a sibling declaration.
/// </summary>
public partial class IFrameClient
{
    private readonly IFrameService _service;

    internal IFrameClient(global::Celitech.SDK.Http.Client httpClient)
    {
        _service = new IFrameService(httpClient);
    }

    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    public IIFrameClient SetConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetConfig(config);
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>TokenAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    public IIFrameClient SetTokenAsyncConfig(global::Celitech.SDK.Config.RequestConfig config)
    {
        _service.SetTokenAsyncConfig(config);
        return this;
    }

    /// <summary>Generate a new token to be used in the iFrame</summary>
    public WithRawResponseTask<TokenResponse> TokenAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) =>
        new WithRawResponseTask<TokenResponse>(
            WithRawResponseAdapter.Wrap(
                options,
                () => _service.TokenAsync(cancellationToken: cancellationToken)
            )
        );
}
