using System.Net.Http.Headers;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.OAuth;

namespace Celitech.SDK.Http.Handlers;

/// <summary>
/// A handler for executing OAuth requests.
/// </summary>
public class OAuthHandler : DelegatingHandler
{
    private TokenManager tokenManager;

    internal OAuthHandler(TokenManager tokenManager, HttpMessageHandler? innerHandler = null)
        : base(innerHandler ?? Client.CreateDefaultTransport())
    {
        this.tokenManager = tokenManager;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        await GetTokenAsync(request, cancellationToken);

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task GetTokenAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var scopes = request.GetScopes();
            if (scopes is not null)
            {
                var token = await this.tokenManager.GetTokenAsync(scopes, cancellationToken);
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token.AccessToken
                );
            }
        }
        // A cancelled request throws OperationCanceledException, which is not an auth failure.
        // Cleaning here would wipe the shared cached token for every other in-flight caller, so
        // let cancellation propagate untouched and only Clean() on genuine auth errors.
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            this.tokenManager.Clean();
            throw;
        }
    }
}
