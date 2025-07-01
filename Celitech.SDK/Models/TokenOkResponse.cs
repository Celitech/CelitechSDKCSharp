using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record TokenOkResponse(
    /// <value>The generated token</value>
    [property:
        JsonPropertyName("token"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Token = null
);
