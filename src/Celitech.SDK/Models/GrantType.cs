using Celitech.SDK.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

[JsonConverter(typeof(GrantType.GrantTypeSerializer))]
[Serializable]
public readonly record struct GrantType : IStringEnum
{
    public static readonly GrantType ClientCredentials = new(Values.ClientCredentials);

    public GrantType(string value)
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
    public static GrantType FromCustom(string value)
    {
        return new GrantType(value);
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

    public static bool operator ==(GrantType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(GrantType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(GrantType value) => value.Value;

    public static explicit operator GrantType(string value) => new(value);

    internal class GrantTypeSerializer : JsonConverter<GrantType>
    {
        public override GrantType Read(
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
            return new GrantType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GrantType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GrantType ReadAsPropertyName(
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
            return new GrantType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GrantType value,
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
        public const string ClientCredentials = "client_credentials";
    }
}
