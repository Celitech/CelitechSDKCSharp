namespace Celitech.SDK.Http.Extensions;

public static class HttpRequestMessageExtensions
{
    private static string _scopesKey = "Scopes";

    /// <summary>
    /// Set the scopes for the request
    /// </summary>
    public static void SetScopes(this HttpRequestMessage request, HashSet<string> scopes)
    {
#if NET5_0_OR_GREATER
        request.Options.Set(new HttpRequestOptionsKey<HashSet<string>>(_scopesKey), scopes);
#else
        request.Properties[_scopesKey] = scopes;
#endif
    }

    /// <summary>
    /// Get the scopes for the request
    /// </summary>>
    public static HashSet<string>? GetScopes(this HttpRequestMessage request)
    {
#if NET5_0_OR_GREATER
        if (
            request.Options.TryGetValue(
                new HttpRequestOptionsKey<HashSet<string>>(_scopesKey),
                out var scopes
            )
        )
#else
        if (
            request.Properties.TryGetValue(_scopesKey, out var _scopesObj)
            && _scopesObj is HashSet<string> scopes
        )
#endif
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
#if NET5_0_OR_GREATER
        if (
            request.Options.TryGetValue(
                new HttpRequestOptionsKey<HashSet<string>>(_scopesKey),
                out var scopes
            )
        )
#else
        if (
            request.Properties.TryGetValue(_scopesKey, out var _scopesObj)
            && _scopesObj is HashSet<string> scopes
        )
#endif
        {
            return scopes.Contains(scope);
        }
        return false;
    }
}
