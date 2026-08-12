using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Celitech.SDK.Json;

/// <summary>
/// Serializes <see cref="DateTime"/> values as ISO-8601 strings with millisecond
/// precision and an offset/UTC suffix (yyyy-MM-ddTHH:mm:ss.fffK).
/// </summary>
public class DateTimeSerializer : JsonConverter<DateTime>
{
    private const string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffK";

    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return DateTime.Parse(
            reader.GetString()!,
            CultureInfo.InvariantCulture,
            DateTimeStyles.RoundtripKind
        );
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateTimeFormat, CultureInfo.InvariantCulture));
    }
}
