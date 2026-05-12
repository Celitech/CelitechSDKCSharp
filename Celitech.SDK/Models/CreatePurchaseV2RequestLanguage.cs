using System.Text.Json.Serialization;
using Celitech.SDK.Json;

namespace Celitech.SDK.Models;

/// <summary>Language of the confirmation email sent to the customer.</summary>
public record CreatePurchaseV2RequestLanguage : ValueEnum<string>
{
    internal CreatePurchaseV2RequestLanguage(string value)
        : base(value) { }

    public CreatePurchaseV2RequestLanguage()
        : base("en") { }

    public static CreatePurchaseV2RequestLanguage En = new("en");
    public static CreatePurchaseV2RequestLanguage Es = new("es");
    public static CreatePurchaseV2RequestLanguage Fr = new("fr");
    public static CreatePurchaseV2RequestLanguage De = new("de");
    public static CreatePurchaseV2RequestLanguage PtBr = new("pt-br");
}
