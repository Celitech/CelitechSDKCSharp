using System.Text.Json.Serialization;

namespace Celitech.SDK.Models;

/// <summary>Duration of the package in days. Available values are 1, 2, 7, 14, 30, or 90. Either provide startDate/endDate or duration.</summary>
public record TopUpEsimRequestDuration : ValueEnum<double>
{
    internal TopUpEsimRequestDuration(double value)
        : base(value) { }

    public TopUpEsimRequestDuration()
        : base(1) { }

    public static TopUpEsimRequestDuration _1 = new(1);
    public static TopUpEsimRequestDuration _2 = new(2);
    public static TopUpEsimRequestDuration _7 = new(7);
    public static TopUpEsimRequestDuration _14 = new(14);
    public static TopUpEsimRequestDuration _30 = new(30);
    public static TopUpEsimRequestDuration _90 = new(90);
}
