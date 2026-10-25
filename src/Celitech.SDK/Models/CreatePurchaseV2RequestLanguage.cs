using Celitech.SDK.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

/// <summary>Language of the confirmation email sent to the customer.</summary>
[JsonConverter(typeof(CreatePurchaseV2RequestLanguage.CreatePurchaseV2RequestLanguageSerializer))]
[Serializable]
public readonly record struct CreatePurchaseV2RequestLanguage : IStringEnum
{
    public static readonly CreatePurchaseV2RequestLanguage En = new(Values.En);

    public static readonly CreatePurchaseV2RequestLanguage Es = new(Values.Es);

    public static readonly CreatePurchaseV2RequestLanguage Fr = new(Values.Fr);

    public static readonly CreatePurchaseV2RequestLanguage De = new(Values.De);

    public static readonly CreatePurchaseV2RequestLanguage PtBr = new(Values.PtBr);

    public CreatePurchaseV2RequestLanguage(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static CreatePurchaseV2RequestLanguage FromCustom(string value)
    {
        return new CreatePurchaseV2RequestLanguage(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(CreatePurchaseV2RequestLanguage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePurchaseV2RequestLanguage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePurchaseV2RequestLanguage value) => value.Value;

    public static explicit operator CreatePurchaseV2RequestLanguage(string value) => new(value);

    internal class CreatePurchaseV2RequestLanguageSerializer
        : JsonConverter<CreatePurchaseV2RequestLanguage>
    {
        public override CreatePurchaseV2RequestLanguage Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CreatePurchaseV2RequestLanguage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePurchaseV2RequestLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePurchaseV2RequestLanguage ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CreatePurchaseV2RequestLanguage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePurchaseV2RequestLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string En = "en";

        public const string Es = "es";

        public const string Fr = "fr";

        public const string De = "de";

        public const string PtBr = "pt-br";
    }
}
