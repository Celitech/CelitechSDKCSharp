using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimHistoryOkResponseEsim(
    /// <value>ID of the eSIM</value>
    [property:
        JsonPropertyName("iccid"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Iccid = null,
    [property:
        JsonPropertyName("history"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        List<History>? History1 = null
);
