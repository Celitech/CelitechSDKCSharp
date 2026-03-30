using Celitech.SDK.Config;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Models;
using Celitech.SDK.Services;

namespace Celitech.SDK.Http.OAuth;

/// <summary>
/// Manages OAuth access tokens with automatic caching, scope tracking, and refresh logic.
/// Ensures tokens are valid and contain required scopes before making API requests.
/// Automatically refreshes tokens when they expire or when additional scopes are needed.
/// </summary>
public class TokenManager
{
    private OauthToken? _token;
    public Uri BaseOAuthUrl { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }

    public TokenManager(CelitechConfig? config = null)
    {
        config ??= new CelitechConfig();
        this.BaseOAuthUrl = new Uri(config.BaseOAuthUrl);
        this.ClientId = config.ClientId;
        this.ClientSecret = config.ClientSecret;
    }

    /// <summary>
    /// Retrieves an OAuth token with the specified scopes, fetching a new one if necessary.
    /// Returns cached token if it's valid and contains all required scopes.
    /// Otherwise, requests a new token that includes all previously cached scopes plus the new ones.
    /// </summary>
    /// <param name="scopes">The OAuth scopes required for the operation.</param>
    /// <returns>A valid OAuth token containing all required scopes.</returns>
    public async Task<OauthToken> GetTokenAsync(HashSet<string> scopes)
    {
        var hasAllScopes = _token != null && _token.Scopes.IsSupersetOf(scopes);

        var validToken =
            _token != null
            && (
                _token.ExpiresAt == null
                || (_token.ExpiresAt.Value - DateTimeOffset.Now.ToUnixTimeSeconds()) > 5000
            );

        if (_token != null && hasAllScopes && validToken)
        {
            return _token;
        }

        if (_token != null)
        {
            scopes.UnionWith(_token.Scopes);
        }

        var response = await GetAccessTokenAsync(scopes);

        if (response.AccessToken == null)
        {
            throw new InvalidOperationException("AccessToken cannot be null");
        }

        _token = new OauthToken(response.AccessToken, scopes, null);

        return _token;
    }

    /// <summary>
    /// Clears the cached OAuth token, forcing a fresh token request on the next GetTokenAsync call.
    /// Typically called after authentication errors or when explicitly logging out.
    /// </summary>
    public void Clean()
    {
        _token = null;
    }

    private async Task<GetAccessTokenOkResponse> GetAccessTokenAsync(HashSet<string> scopes)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = this.BaseOAuthUrl.EnsureTrailingSlash(),
            DefaultRequestHeaders = { { "user-agent", "dotnet/7.0" } },
        };
        var service = new OAuthService(httpClient);

        var response = await service.GetAccessTokenAsync(
            input: new GetAccessTokenRequest(
                GrantType: GrantType.ClientCredentials,
                ClientId: this.ClientId,
                ClientSecret: this.ClientSecret
            )
        );

        return response;
    }
}
