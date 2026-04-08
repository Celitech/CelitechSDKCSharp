using System.Text.Json.Serialization;

namespace Celitech.Models;

public record GetAccessTokenOkResponse(
    [property:
        JsonPropertyName("access_token"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ]
        Optional<string> AccessToken = default,
    [property:
        JsonPropertyName("token_type"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ]
        Optional<string> TokenType = default,
    [property:
        JsonPropertyName("expires_in"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ]
        Optional<long> ExpiresIn = default
);
