using Celitech.SDK.Config;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Models;
using Celitech.SDK.Services;

namespace Celitech.SDK.Http.OAuth;

/// <summary>
/// Manages OAuth access tokens with automatic caching, scope tracking, and refresh logic.
/// Ensures tokens are valid and contain required scopes before making API requests.
/// Automatically refreshes tokens when they expire or when additional scopes are needed.
/// Token acquisition is synchronized so that concurrent requests share a single fetch.
/// </summary>
public class TokenManager : IDisposable
{
    private OauthToken? _token;
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly Client httpClient;
    public Uri BaseOAuthUrl { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }

    public TokenManager(Client httpClient, CelitechConfig? config = null)
    {
        this.httpClient = httpClient;
        config ??= new CelitechConfig();
        this.BaseOAuthUrl = new Uri(config.BaseOAuthUrl);
        this.ClientId = config.ClientId;
        this.ClientSecret = config.ClientSecret;
        httpClient.SetBaseAddress(this.BaseOAuthUrl);
    }

    /// <summary>
    /// Retrieves an OAuth token with the specified scopes, fetching a new one if necessary.
    /// Returns cached token if it's valid and contains all required scopes.
    /// Otherwise, requests a new token that includes all previously cached scopes plus the new ones.
    /// </summary>
    /// <param name="scopes">The OAuth scopes required for the operation.</param>
    /// <param name="cancellationToken">Token used to cancel the queued wait and the token fetch.</param>
    /// <returns>A valid OAuth token containing all required scopes.</returns>
    public async Task<OauthToken> GetTokenAsync(
        HashSet<string> scopes,
        CancellationToken cancellationToken = default
    )
    {
        var cached = Volatile.Read(ref _token);
        if (cached != null && cached.Scopes.IsSupersetOf(scopes) && IsTokenValid(cached))
        {
            return cached;
        }

        await _lock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            // Re-check under the lock: a caller released here may find that another
            // request already fetched a token that satisfies this one (no re-fetch needed).
            cached = _token;
            if (cached != null && cached.Scopes.IsSupersetOf(scopes) && IsTokenValid(cached))
            {
                return cached;
            }

            // The fetch below runs while holding the lock, so a request for a different scope set
            // waits for the in-flight fetch and then fetches a superset. This intentionally trades
            // concurrency of unrelated-scope requests for far fewer token-endpoint calls.
            // Accumulate previously granted scopes onto a private copy so the caller's set is never mutated.
            var required = new HashSet<string>(scopes);
            if (cached != null)
            {
                required.UnionWith(cached.Scopes);
            }

            var response = await GetAccessTokenAsync(required, cancellationToken)
                .ConfigureAwait(false);

            if (response.AccessToken == null)
            {
                throw new InvalidOperationException("AccessToken cannot be null");
            }

            var newToken = new OauthToken(
                response.AccessToken,
                required,
                response.ExpiresIn.HasValue
                    ? (long?)(DateTimeOffset.UtcNow.ToUnixTimeSeconds() + response.ExpiresIn.Value)
                    : null
            );

            Volatile.Write(ref _token, newToken);
            return newToken;
        }
        finally
        {
            _lock.Release();
        }
    }

    private bool IsTokenValid(OauthToken token)
    {
        return token.ExpiresAt == null
            || (token.ExpiresAt.Value - DateTimeOffset.UtcNow.ToUnixTimeSeconds()) > 5;
    }

    /// <summary>
    /// Clears the cached OAuth token, forcing a fresh token request on the next GetTokenAsync call.
    /// Typically called after authentication errors or when explicitly logging out.
    /// </summary>
    public void Clean()
    {
        // Lock-free on purpose: nulling a reference is atomic, and racing an in-flight fetch's
        // assignment is benign (either the token is cleared or the freshly fetched token wins).
        // Taking the lock here would instead block the caller for a full token round-trip when
        // Clean() runs while a fetch is in progress.
        Volatile.Write(ref _token, null);
    }

    private async Task<OAuthTokenResponse> GetAccessTokenAsync(
        HashSet<string> scopes,
        CancellationToken cancellationToken
    )
    {
        if (this.ClientId == null)
        {
            throw new ArgumentNullException(nameof(ClientId), "ClientId is required.");
        }
        if (this.ClientSecret == null)
        {
            throw new ArgumentNullException(nameof(ClientSecret), "ClientSecret is required.");
        }
        var service = new OAuthService(httpClient);

        var response = await service
            .GetAccessTokenAsync(
                input: new OAuthTokenRequest(
                    GrantType: GrantType.ClientCredentials,
                    ClientId: this.ClientId,
                    ClientSecret: this.ClientSecret,
                    Scope: string.Join(" ", scopes)
                ),
                cancellationToken: cancellationToken
            )
            .ConfigureAwait(false);

        return response;
    }

    public void Dispose()
    {
        _lock.Dispose();
    }
}
