using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record OAuthTokenRequest(
    [property: JsonPropertyName("grant_type")] GrantType GrantType,
    [property: JsonPropertyName("client_id")] string ClientId,
    [property: JsonPropertyName("client_secret")] string ClientSecret,
    [property: JsonPropertyName("scope")] string Scope
);
