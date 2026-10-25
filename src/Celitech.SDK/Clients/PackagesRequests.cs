using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Celitech.SDK;

[Serializable]
public record ListPackagesRequest
{
    [JsonIgnore]
    public string? Destination { get; set; }

    [JsonIgnore]
    public double? DataLimitInGb { get; set; }

    [JsonIgnore]
    public DateOnly? StartDate { get; set; }

    [JsonIgnore]
    public DateOnly? EndDate { get; set; }

    [JsonIgnore]
    public string? AfterCursor { get; set; }

    [JsonIgnore]
    public double? Limit { get; set; }

    [JsonIgnore]
    public int? StartTime { get; set; }

    [JsonIgnore]
    public int? EndTime { get; set; }

    [JsonIgnore]
    public bool? IncludeUnlimited { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
