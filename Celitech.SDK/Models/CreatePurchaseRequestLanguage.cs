using System.Text.Json.Serialization;
using Celitech.SDK.Json;

namespace Celitech.SDK.Models;

/// <summary>Language of the confirmation email sent to the customer.</summary>
public record CreatePurchaseRequestLanguage : ValueEnum<string>
{
    internal CreatePurchaseRequestLanguage(string value)
        : base(value) { }

    public CreatePurchaseRequestLanguage()
        : base("en") { }

    public static CreatePurchaseRequestLanguage En = new("en");
    public static CreatePurchaseRequestLanguage Es = new("es");
    public static CreatePurchaseRequestLanguage Fr = new("fr");
    public static CreatePurchaseRequestLanguage De = new("de");
    public static CreatePurchaseRequestLanguage PtBr = new("pt-br");
}
