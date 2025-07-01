using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Package(
    /// <value>ID of the package</value>
    [property: JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Id = null,
    /// <value>Size of the package in Bytes</value>
    [property:
        JsonPropertyName("dataLimitInBytes"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? DataLimitInBytes = null,
    /// <value>ISO representation of the package's destination.</value>
    [property:
        JsonPropertyName("destination"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? Destination = null,
    /// <value>Name of the package's destination</value>
    [property:
        JsonPropertyName("destinationName"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        string? DestinationName = null,
    /// <value>Price of the package in cents</value>
    [property:
        JsonPropertyName("priceInCents"),
        JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
    ]
        double? PriceInCents = null
);
