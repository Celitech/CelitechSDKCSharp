using Celitech.SDK.Config;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Handlers;
using Celitech.SDK.Http.OAuth;
using Celitech.SDK.Services;
using Environment = Celitech.SDK.Http.Environment;

namespace Celitech.SDK;

public class CelitechClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly TokenManager _tokenManager;

    public OAuthService OAuth { get; private set; }
    public DestinationsService Destinations { get; private set; }
    public PackagesService Packages { get; private set; }
    public PurchasesService Purchases { get; private set; }
    public ESimService ESim { get; private set; }
    public IFrameService IFrame { get; private set; }

    public CelitechClient(CelitechConfig? config = null)
    {
        var retryHandler = new RetryHandler();
        _tokenManager = new TokenManager(config);
        var oauthHandler = new OAuthHandler(_tokenManager, retryHandler);
        _httpClient = new HttpClient(oauthHandler)
        {
            BaseAddress = config?.Environment?.Uri ?? Environment.Default.Uri,
            DefaultRequestHeaders = { { "user-agent", "dotnet/7.0" } },
        };

        OAuth = new OAuthService(_httpClient);
        Destinations = new DestinationsService(_httpClient);
        Packages = new PackagesService(_httpClient);
        Purchases = new PurchasesService(_httpClient);
        ESim = new ESimService(_httpClient);
        IFrame = new IFrameService(_httpClient);
    }

    /// <summary>
    /// Set the environment for the entire SDK.
    /// </summary>
    public void SetEnvironment(Environment environment)
    {
        SetBaseUrl(environment.Uri);
    }

    /// <summary>
    /// Sets the base URL for the entire SDK.
    /// </summary>
    public void SetBaseUrl(string baseUrl)
    {
        SetBaseUrl(new Uri(baseUrl));
    }

    /// <summary>
    /// Sets the base URL for the entire SDK.
    /// </summary>
    public void SetBaseUrl(Uri uri)
    {
        _httpClient.BaseAddress = uri.EnsureTrailingSlash();
    }

    /// <summary>
    /// Set the OAuth base URL for the entire SDK.
    /// </summary>
    public void SetOAuthBaseUrl(string baseUrl)
    {
        SetOAuthBaseUrl(new Uri(baseUrl));
    }

    /// <summary>
    /// Sets the OAuth base URL for the entire SDK.
    /// </summary>
    public void SetOAuthBaseUrl(Uri uri)
    {
        _tokenManager.BaseOAuthUrl = uri.EnsureTrailingSlash();
        _tokenManager.Clean();
    }

    /// <summary>
    /// Sets the OAuth parameter 'ClientId' for the entire SDK.
    /// </summary>
    public void SetClientId(string ClientId)
    {
        _tokenManager.ClientId = ClientId;
        _tokenManager.Clean();
    }

    /// <summary>
    /// Sets the OAuth parameter 'ClientSecret' for the entire SDK.
    /// </summary>
    public void SetClientSecret(string ClientSecret)
    {
        _tokenManager.ClientSecret = ClientSecret;
        _tokenManager.Clean();
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}

// c029837e0e474b76bc487506e8799df5e3335891efe4fb02bda7a1441840310c
