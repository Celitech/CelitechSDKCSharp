using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Threading;
using OneOf;

namespace Celitech.SDK;

/// <summary>
/// Fern-shape interface for IFrameClient. Mirrors the public surface of <c>IFrameClient</c>
/// (methods and child clients) so callers can depend on the abstraction (mockability). FSM-144.
/// </summary>
public partial interface IIFrameClient
{
    /// <summary>
    /// Sets service-level configuration for every method on this client.
    /// Overridden by method-level config and by per-call <c>RequestOptions</c>.
    /// </summary>
    IIFrameClient SetConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>
    /// Sets method-level configuration for <c>TokenAsync</c>.
    /// Overrides service-level configuration; overridden by per-call <c>RequestOptions</c>.
    /// </summary>
    IIFrameClient SetTokenAsyncConfig(global::Celitech.SDK.Config.RequestConfig config);

    /// <summary>Generate a new token to be used in the iFrame</summary>
    WithRawResponseTask<TokenResponse> TokenAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}

public partial class IFrameClient : IIFrameClient { }
