using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetAccessTokenOkResponse(
    [property:
        JsonPropertyName("access_token"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? AccessToken = null,
    [property:
        JsonPropertyName("token_type"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? TokenType = null,
    [property:
        JsonPropertyName("expires_in"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        long? ExpiresIn = null
);
