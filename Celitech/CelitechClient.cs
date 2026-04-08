using Celitech.Config;
using Celitech.Http;
using Celitech.Http.Extensions;
using Celitech.Http.Handlers;
using Celitech.Http.OAuth;
using Celitech.Services;
using Environment = Celitech.Http.Environment;

namespace Celitech;

/// <summary>
/// The main SDK client that provides access to all service endpoints.
/// Manages HTTP client lifecycle, authentication handlers, and service instances with centralized configuration.
/// Implements IDisposable to properly clean up HTTP resources.
/// </summary>
public class CelitechClient : IDisposable
{
    private readonly Client _httpClient;
    private readonly Client _tokenHttpClient;

    private readonly TokenManager _tokenManager;

    public DestinationsService Destinations { get; private set; }
    public PackagesService Packages { get; private set; }
    public PurchasesService Purchases { get; private set; }
    public ESimService ESim { get; private set; }
    public IFrameService IFrame { get; private set; }

    public CelitechClient(CelitechConfig? config = null)
    {
        var retryHandler = new RetryHandler();
        _tokenHttpClient = new Client(config);
        _tokenManager = new TokenManager(_tokenHttpClient, config);
        var oauthHandler = new OAuthHandler(_tokenManager, retryHandler);
        _httpClient = new Client(config, oauthHandler);

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
        _tokenHttpClient.SetBaseAddress(uri.EnsureTrailingSlash());
        _httpClient.SetBaseAddress(uri.EnsureTrailingSlash());
    }

    /// <summary>
    /// Sets the timeout for the entire SDK.
    /// </summary>
    /// <param name="timeout">The timeout value. Must be a positive TimeSpan or Timeout.InfiniteTimeSpan.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the timeout is not valid.</exception>
    public void SetTimeout(TimeSpan timeout)
    {
        if (timeout <= TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan)
        {
            throw new ArgumentOutOfRangeException(
                nameof(timeout),
                "Timeout must be a positive value or Timeout.InfiniteTimeSpan."
            );
        }

        _tokenHttpClient.SetTimeout(timeout);
        _httpClient.SetTimeout(timeout);
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
