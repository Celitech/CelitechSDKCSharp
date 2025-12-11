using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

/// <summary>Duration of the package in days. Available values are 1, 2, 7, 14, 30, or 90. Either provide startDate/endDate or duration.</summary>
public record CreatePurchaseV2RequestDuration : ValueEnum<double>
{
    internal CreatePurchaseV2RequestDuration(double value)
        : base(value) { }

    public CreatePurchaseV2RequestDuration()
        : base(1) { }

    public static CreatePurchaseV2RequestDuration _1 = new(1);
    public static CreatePurchaseV2RequestDuration _2 = new(2);
    public static CreatePurchaseV2RequestDuration _7 = new(7);
    public static CreatePurchaseV2RequestDuration _14 = new(14);
    public static CreatePurchaseV2RequestDuration _30 = new(30);
    public static CreatePurchaseV2RequestDuration _90 = new(90);
}
