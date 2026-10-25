using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Celitech.SDK;

[Serializable]
public record GetEsimRequest
{
    [JsonIgnore]
    public required string Iccid { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetEsimDeviceRequest
{
    [JsonIgnore]
    public required string Iccid { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetEsimHistoryRequest
{
    [JsonIgnore]
    public required string Iccid { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record SuspendEsimRequest
{
    [JsonIgnore]
    public required string Iccid { get; set; }

    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
