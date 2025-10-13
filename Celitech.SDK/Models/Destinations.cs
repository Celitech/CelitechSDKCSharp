using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record Destinations(
    /// <value>Name of the destination</value>
    [property: JsonPropertyName("name")]
        string Name,
    /// <value>ISO3 representation of the destination</value>
    [property: JsonPropertyName("destination")]
        string Destination,
    /// <value>ISO2 representation of the destination</value>
    [property: JsonPropertyName("destinationISO2")]
        string DestinationIso2,
    /// <value>This array indicates the geographical area covered by a specific destination. If the destination represents a single country, the array will include that country. However, if the destination represents a broader regional scope, the array will be populated with the names of the countries belonging to that region.</value>
    [property: JsonPropertyName("supportedCountries")]
        List<string> SupportedCountries
);
