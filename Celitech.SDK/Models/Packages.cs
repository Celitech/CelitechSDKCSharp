using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Packages(
    /// <value>ID of the package</value>
    [property: JsonPropertyName("id")]
        string Id,
    /// <value>ISO3 representation of the package's destination.</value>
    [property: JsonPropertyName("destination")]
        string Destination,
    /// <value>ISO2 representation of the package's destination.</value>
    [property: JsonPropertyName("destinationISO2")]
        string DestinationIso2,
    /// <value>Size of the package in Bytes</value>
    [property: JsonPropertyName("dataLimitInBytes")]
        double DataLimitInBytes,
    /// <value>Min number of days for the package</value>
    [property: JsonPropertyName("minDays")]
        double MinDays,
    /// <value>Max number of days for the package</value>
    [property: JsonPropertyName("maxDays")]
        double MaxDays,
    /// <value>Price of the package in cents</value>
    [property: JsonPropertyName("priceInCents")]
        double PriceInCents
);
