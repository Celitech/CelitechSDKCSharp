using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Celitech.SDK;

[Serializable]
public record CreatePurchaseV2Request
{
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required string Destination { get; set; }

    [JsonIgnore]
    public required double DataLimitInGb { get; set; }

    [JsonIgnore]
    public DateOnly? StartDate { get; set; }

    [JsonIgnore]
    public DateOnly? EndDate { get; set; }

    [JsonIgnore]
    public double? Duration { get; set; }

    [JsonIgnore]
    public required double Quantity { get; set; }

    [JsonIgnore]
    public string? Email { get; set; }

    [JsonIgnore]
    public string? ReferenceId { get; set; }

    [JsonIgnore]
    public string? NetworkBrand { get; set; }

    [JsonIgnore]
    public string? EmailBrand { get; set; }

    [JsonIgnore]
    public CreatePurchaseV2RequestLanguage? Language { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record ListPurchasesRequest
{
    [JsonIgnore]
    public string? PurchaseId { get; set; }

    [JsonIgnore]
    public string? Iccid { get; set; }

    [JsonIgnore]
    public DateOnly? AfterDate { get; set; }

    [JsonIgnore]
    public DateOnly? BeforeDate { get; set; }

    [JsonIgnore]
    public string? Email { get; set; }

    [JsonIgnore]
    public string? ReferenceId { get; set; }

    [JsonIgnore]
    public string? AfterCursor { get; set; }

    [JsonIgnore]
    public double? Limit { get; set; }

    [JsonIgnore]
    public double? After { get; set; }

    [JsonIgnore]
    public double? Before { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record CreatePurchaseRequest
{
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required string Destination { get; set; }

    [JsonIgnore]
    public required double DataLimitInGb { get; set; }

    [JsonIgnore]
    public required DateOnly StartDate { get; set; }

    [JsonIgnore]
    public required DateOnly EndDate { get; set; }

    [JsonIgnore]
    public string? Email { get; set; }

    [JsonIgnore]
    public string? ReferenceId { get; set; }

    [JsonIgnore]
    public string? NetworkBrand { get; set; }

    [JsonIgnore]
    public string? EmailBrand { get; set; }

    [JsonIgnore]
    public CreatePurchaseRequestLanguage? Language { get; set; }

    [JsonIgnore]
    public double? StartTime { get; set; }

    [JsonIgnore]
    public double? EndTime { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record TopUpEsimRequest
{
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required string Iccid { get; set; }

    [JsonIgnore]
    public required double DataLimitInGb { get; set; }

    [JsonIgnore]
    public DateOnly? StartDate { get; set; }

    [JsonIgnore]
    public DateOnly? EndDate { get; set; }

    [JsonIgnore]
    public double? Duration { get; set; }

    [JsonIgnore]
    public string? Email { get; set; }

    [JsonIgnore]
    public string? ReferenceId { get; set; }

    [JsonIgnore]
    public string? EmailBrand { get; set; }

    [JsonIgnore]
    public double? StartTime { get; set; }

    [JsonIgnore]
    public double? EndTime { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record EditPurchaseRequest
{
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonIgnore]
    public required string PurchaseId { get; set; }

    [JsonIgnore]
    public required DateOnly StartDate { get; set; }

    [JsonIgnore]
    public required DateOnly EndDate { get; set; }

    [JsonIgnore]
    public double? StartTime { get; set; }

    [JsonIgnore]
    public double? EndTime { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

[Serializable]
public record GetPurchaseConsumptionRequest
{
    [JsonIgnore]
    public required string PurchaseId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
