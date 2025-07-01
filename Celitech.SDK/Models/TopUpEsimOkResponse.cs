using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record TopUpEsimOkResponse(
    [property:
        JsonPropertyName("purchase"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        TopUpEsimOkResponsePurchase? Purchase = null,
    [property:
        JsonPropertyName("profile"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        TopUpEsimOkResponseProfile? Profile = null
);
