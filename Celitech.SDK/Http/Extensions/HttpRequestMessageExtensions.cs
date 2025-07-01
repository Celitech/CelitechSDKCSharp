namespace Celitech.SDK.Http.Extensions;

public static class HttpRequestMessageExtensions
{
    private static string _scopesKey = "Scopes";

    /// <summary>
    /// Set the scopes for the request
    /// </summary>
    public static void SetScopes(this HttpRequestMessage request, HashSet<string> scopes)
    {
        request.Options.Set(new HttpRequestOptionsKey<HashSet<string>>(_scopesKey), scopes);
    }

    /// <summary>
    /// Get the scopes for the request
    /// </summary>>
    public static HashSet<string>? GetScopes(this HttpRequestMessage request)
    {
        if (
            request.Options.TryGetValue(
                new HttpRequestOptionsKey<HashSet<string>>(_scopesKey),
                out var scopes
            )
        )
        {
            return scopes;
        }
        return null;
    }

    /// <summary>
    /// Check if the request has the specified scope
    /// </summary>
    public static bool HasScope(this HttpRequestMessage request, string scope)
    {
        if (
            request.Options.TryGetValue(
                new HttpRequestOptionsKey<HashSet<string>>(_scopesKey),
                out var scopes
            )
        )
        {
            return scopes.Contains(scope);
        }
        return false;
    }
}
