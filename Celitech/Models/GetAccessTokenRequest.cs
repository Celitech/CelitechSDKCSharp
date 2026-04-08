using System.Text.Json.Serialization;
using Celitech.Json;

namespace Celitech.Models;

public record GetAccessTokenRequest(
    [property:
        JsonPropertyName("grant_type"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ]
        Optional<GrantType> GrantType = default,
    [property:
        JsonPropertyName("client_id"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ]
        Optional<string> ClientId = default,
    [property:
        JsonPropertyName("client_secret"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)
    ]
        Optional<string> ClientSecret = default
);
