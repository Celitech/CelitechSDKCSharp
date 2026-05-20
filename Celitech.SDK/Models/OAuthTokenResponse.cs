using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record OAuthTokenResponse(
    [property:
        JsonPropertyName("access_token"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AccessToken = null,
    [property: JsonPropertyName("expires_in")] long? ExpiresIn = null
);
