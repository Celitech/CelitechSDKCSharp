using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record ListDestinationsOkResponse(
    [property: JsonPropertyName("destinations")] List<Destinations> Destinations1
);
