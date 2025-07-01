using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record GetEsimOkResponse(
    [property:
        JsonPropertyName("esim"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        GetEsimOkResponseEsim? Esim = null
);
