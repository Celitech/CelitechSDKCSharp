using System.Text.Json.Serialization;

namespace Celitech.Models;

public record ListDestinationsOkResponse(
    [property: JsonPropertyName("destinations")] List<Destinations> Destinations
);
