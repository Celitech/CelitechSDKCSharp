using Celitech.SDK.Models;
using Environment = Celitech.SDK.Http.Environment;

namespace Celitech.SDK.Config;

/// <summary>
/// Configuration options for the CelitechClient.
/// </summary>
public record CelitechConfig(
    /// <value>The environment to use for the SDK.</value>
    Environment? Environment = null,
    /// <value>The base OAuth URL.</value>
    string BaseOAuthUrl = "https://auth.celitech.net",
    /// <value>The ClientId parameter.</value>
    Optional<string> ClientId = default,
    /// <value>The ClientSecret parameter.</value>
    Optional<string> ClientSecret = default
);
