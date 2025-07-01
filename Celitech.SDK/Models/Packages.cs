using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Packages(
    /// <value>ID of the package</value>
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Id = null,
    /// <value>ISO representation of the package's destination.</value>
    [property:
        JsonPropertyName("destination"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Destination = null,
    /// <value>Size of the package in Bytes</value>
    [property:
        JsonPropertyName("dataLimitInBytes"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DataLimitInBytes = null,
    /// <value>Min number of days for the package</value>
    [property:
        JsonPropertyName("minDays"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? MinDays = null,
    /// <value>Max number of days for the package</value>
    [property:
        JsonPropertyName("maxDays"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? MaxDays = null,
    /// <value>Price of the package in cents</value>
    [property:
        JsonPropertyName("priceInCents"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? PriceInCents = null
);
