using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimMacOkResponseEsim(
    /// <value>ID of the eSIM</value>
    [property:
        JsonPropertyName("iccid"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Iccid = null,
    /// <value>SM-DP+ Address</value>
    [property:
        JsonPropertyName("smdpAddress"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? SmdpAddress = null,
    /// <value>The manual activation code</value>
    [property:
        JsonPropertyName("manualActivationCode"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? ManualActivationCode = null
);
