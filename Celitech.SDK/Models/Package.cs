using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Package(
    /// <value>ID of the package</value>
    [property: JsonPropertyName("id")]
        string Id,
    /// <value>Size of the package in Bytes</value>
    [property: JsonPropertyName("dataLimitInBytes")]
        double DataLimitInBytes,
    /// <value>ISO3 representation of the package's destination.</value>
    [property: JsonPropertyName("destination")]
        string Destination,
    /// <value>ISO2 representation of the package's destination.</value>
    [property: JsonPropertyName("destinationISO2")]
        string DestinationIso2,
    /// <value>Name of the package's destination</value>
    [property: JsonPropertyName("destinationName")]
        string DestinationName,
    /// <value>Price of the package in cents</value>
    [property: JsonPropertyName("priceInCents")]
        double PriceInCents
);
