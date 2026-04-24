namespace Celitech.SDK.Http.OAuth;

/// <summary>
/// Represents an OAuth access token with its associated scopes and expiration time.
/// Used for caching and validating tokens before making authenticated API requests.
/// </summary>
/// <param name="AccessToken">The OAuth 2.0 access token string.</param>
/// <param name="Scopes">The set of OAuth scopes granted to this token.</param>
/// <param name="ExpiresAt">Unix timestamp (seconds since epoch) when the token expires, or null if it doesn't expire.</param>
public record OauthToken(string AccessToken, HashSet<string> Scopes, long? ExpiresAt);
