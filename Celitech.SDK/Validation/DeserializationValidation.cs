using System.Collections.Generic;
using System.Text.Json;
using Celitech.SDK.Models;

namespace Celitech.SDK.Validation;

/// <summary>
/// Helper class for custom JSON deserialization with required field validation
/// </summary>
public static class DeserializationValidation
{
    /// <summary>
    /// Deserializes JSON content with validation for required fields
    /// </summary>
    /// <typeparam name="T">The type to deserialize to</typeparam>
    /// <param name="jsonContent">The JSON content to deserialize</param>
    /// <param name="jsonSerializerOptions">JSON serializer options</param>
    /// <returns>The deserialized object</returns>
    /// <exception cref="JsonException">Thrown when required fields are missing from the JSON</exception>
    public static T DeserializeWithRequiredFieldValidation<T>(
        string jsonContent,
        JsonSerializerOptions jsonSerializerOptions
    )
    {
        // Parse JSON to check for missing required fields
        using var document = JsonDocument.Parse(jsonContent);
        var root = document.RootElement;

        // Validate required fields for the specific response type
        ValidateRequiredFieldsForResponse<T>(root);

        // Deserialize normally after validation
        return JsonSerializer.Deserialize<T>(jsonContent, jsonSerializerOptions)
            ?? throw new Exception("Failed to deserialize response.");
    }

    private static readonly Dictionary<Type, Action<JsonElement>> ValidationMethods = new()
    {
        { typeof(OAuthTokenRequest), ValidateRequiredFieldsForOAuthTokenRequest },
    };

    private static void ValidateRequiredFieldsForResponse<T>(JsonElement root)
    {
        if (ValidationMethods.TryGetValue(typeof(T), out var validator))
        {
            validator(root);
        }
    }

    private static void ValidateRequiredFieldsForOAuthTokenRequest(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "grant_type",
            "client_id",
            "client_secret",
            "scope",
        };

        var missingFields = new List<string>();

        // Check non-nullable required fields
        foreach (var field in nonNullableRequiredFields)
        {
            if (
                !root.TryGetProperty(field, out var property)
                || property.ValueKind == JsonValueKind.Null
            )
            {
                missingFields.Add(field);
            }
        }

        if (missingFields.Any())
        {
            throw new JsonException(
                $"Required fields are missing from JSON response: {string.Join(", ", missingFields)}"
            );
        }
    }
}
