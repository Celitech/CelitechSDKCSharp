using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Celitech.SDK.Json;

/// <summary>
/// Serializes <see cref="DateOnly"/> values as ISO-8601 date strings (yyyy-MM-dd).
/// System.Text.Json on net6.0 has no built-in DateOnly converter.
/// </summary>
public sealed class DateOnlyConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";

    public override DateOnly Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return DateOnly.ParseExact(reader.GetString()!, Format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}
