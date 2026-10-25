using Celitech.SDK.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

/// <summary>Language of the confirmation email sent to the customer.</summary>
[JsonConverter(typeof(CreatePurchaseRequestLanguage.CreatePurchaseRequestLanguageSerializer))]
[Serializable]
public readonly record struct CreatePurchaseRequestLanguage : IStringEnum
{
    public static readonly CreatePurchaseRequestLanguage En = new(Values.En);

    public static readonly CreatePurchaseRequestLanguage Es = new(Values.Es);

    public static readonly CreatePurchaseRequestLanguage Fr = new(Values.Fr);

    public static readonly CreatePurchaseRequestLanguage De = new(Values.De);

    public static readonly CreatePurchaseRequestLanguage PtBr = new(Values.PtBr);

    public CreatePurchaseRequestLanguage(string value)
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
    public static CreatePurchaseRequestLanguage FromCustom(string value)
    {
        return new CreatePurchaseRequestLanguage(value);
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

    public static bool operator ==(CreatePurchaseRequestLanguage value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatePurchaseRequestLanguage value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatePurchaseRequestLanguage value) => value.Value;

    public static explicit operator CreatePurchaseRequestLanguage(string value) => new(value);

    internal class CreatePurchaseRequestLanguageSerializer
        : JsonConverter<CreatePurchaseRequestLanguage>
    {
        public override CreatePurchaseRequestLanguage Read(
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
            return new CreatePurchaseRequestLanguage(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatePurchaseRequestLanguage value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatePurchaseRequestLanguage ReadAsPropertyName(
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
            return new CreatePurchaseRequestLanguage(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatePurchaseRequestLanguage value,
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
