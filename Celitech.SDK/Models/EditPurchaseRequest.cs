using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

public record EditPurchaseRequest(
    [property: JsonPropertyName("purchaseId")] string? PurchaseId = null,
    [property: JsonPropertyName("startDate")] string? StartDate = null,
    [property: JsonPropertyName("endDate")] string? EndDate = null,
    [property: JsonPropertyName("startTime")] double? StartTime = null,
    [property: JsonPropertyName("endTime")] double? EndTime = null
);
