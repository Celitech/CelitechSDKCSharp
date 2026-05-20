using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record CreatePurchaseRequest(
    [property: JsonPropertyName("destination")] string? Destination = null,
    [property: JsonPropertyName("dataLimitInGB")] double? DataLimitInGb = null,
    [property: JsonPropertyName("startDate")] string? StartDate = null,
    [property: JsonPropertyName("endDate")] string? EndDate = null,
    [property: JsonPropertyName("email")] string? Email = null,
    [property: JsonPropertyName("referenceId")] string? ReferenceId = null,
    [property: JsonPropertyName("networkBrand")] string? NetworkBrand = null,
    [property: JsonPropertyName("emailBrand")] string? EmailBrand = null,
    [property: JsonPropertyName("language")] string? Language = null,
    [property: JsonPropertyName("startTime")] double? StartTime = null,
    [property: JsonPropertyName("endTime")] double? EndTime = null
);
