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
        : base(innerHandler ?? new HttpClientHandler())
    {
        this.tokenManager = tokenManager;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        await GetTokenAsync(request);

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task GetTokenAsync(HttpRequestMessage request)
    {
        try
        {
            var scopes = request.GetScopes();
            if (scopes is not null)
            {
                var token = await this.tokenManager.GetTokenAsync(scopes);
                request.Headers.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token.AccessToken
                );
            }
        }
        catch (Exception)
        {
            this.tokenManager.Clean();
            throw;
        }
    }
}
