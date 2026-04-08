using System.Collections.Generic;
using System.Text.Json;
using Celitech.Models;

namespace Celitech.Validation;

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
        { typeof(ListDestinationsOkResponse), ValidateRequiredFieldsForListDestinationsOkResponse },
        { typeof(ListPackagesOkResponse), ValidateRequiredFieldsForListPackagesOkResponse },
        { typeof(CreatePurchaseV2Request), ValidateRequiredFieldsForCreatePurchaseV2Request },
        { typeof(CreatePurchaseV2OkResponse), ValidateRequiredFieldsForCreatePurchaseV2OkResponse },
        { typeof(ListPurchasesOkResponse), ValidateRequiredFieldsForListPurchasesOkResponse },
        { typeof(CreatePurchaseRequest), ValidateRequiredFieldsForCreatePurchaseRequest },
        { typeof(CreatePurchaseOkResponse), ValidateRequiredFieldsForCreatePurchaseOkResponse },
        { typeof(TopUpEsimRequest), ValidateRequiredFieldsForTopUpEsimRequest },
        { typeof(TopUpEsimOkResponse), ValidateRequiredFieldsForTopUpEsimOkResponse },
        { typeof(EditPurchaseRequest), ValidateRequiredFieldsForEditPurchaseRequest },
        { typeof(EditPurchaseOkResponse), ValidateRequiredFieldsForEditPurchaseOkResponse },
        {
            typeof(GetPurchaseConsumptionOkResponse),
            ValidateRequiredFieldsForGetPurchaseConsumptionOkResponse
        },
        { typeof(GetEsimOkResponse), ValidateRequiredFieldsForGetEsimOkResponse },
        { typeof(GetEsimDeviceOkResponse), ValidateRequiredFieldsForGetEsimDeviceOkResponse },
        { typeof(GetEsimHistoryOkResponse), ValidateRequiredFieldsForGetEsimHistoryOkResponse },
        { typeof(TokenOkResponse), ValidateRequiredFieldsForTokenOkResponse },
        { typeof(Destinations), ValidateRequiredFieldsForDestinations },
        { typeof(Packages), ValidateRequiredFieldsForPackages },
        {
            typeof(CreatePurchaseV2OkResponsePurchase),
            ValidateRequiredFieldsForCreatePurchaseV2OkResponsePurchase
        },
        {
            typeof(CreatePurchaseV2OkResponseProfile),
            ValidateRequiredFieldsForCreatePurchaseV2OkResponseProfile
        },
        { typeof(Purchases), ValidateRequiredFieldsForPurchases },
        { typeof(Package), ValidateRequiredFieldsForPackage },
        { typeof(PurchasesEsim), ValidateRequiredFieldsForPurchasesEsim },
        {
            typeof(CreatePurchaseOkResponsePurchase),
            ValidateRequiredFieldsForCreatePurchaseOkResponsePurchase
        },
        {
            typeof(CreatePurchaseOkResponseProfile),
            ValidateRequiredFieldsForCreatePurchaseOkResponseProfile
        },
        {
            typeof(TopUpEsimOkResponsePurchase),
            ValidateRequiredFieldsForTopUpEsimOkResponsePurchase
        },
        { typeof(TopUpEsimOkResponseProfile), ValidateRequiredFieldsForTopUpEsimOkResponseProfile },
        { typeof(GetEsimOkResponseEsim), ValidateRequiredFieldsForGetEsimOkResponseEsim },
        { typeof(Device), ValidateRequiredFieldsForDevice },
        {
            typeof(GetEsimHistoryOkResponseEsim),
            ValidateRequiredFieldsForGetEsimHistoryOkResponseEsim
        },
        { typeof(History), ValidateRequiredFieldsForHistory },
    };

    private static void ValidateRequiredFieldsForResponse<T>(JsonElement root)
    {
        if (ValidationMethods.TryGetValue(typeof(T), out var validator))
        {
            validator(root);
        }
    }

    private static void ValidateRequiredFieldsForListDestinationsOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "destinations" };

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

    private static void ValidateRequiredFieldsForListPackagesOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "packages" };

        // Nullable required fields - must be present but can be null
        var nullableRequiredFields = new[] { "afterCursor" };

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

        // Check nullable required fields (must be present but can be null)
        foreach (var field in nullableRequiredFields)
        {
            if (!root.TryGetProperty(field, out _))
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

    private static void ValidateRequiredFieldsForCreatePurchaseV2Request(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "destination", "dataLimitInGB", "quantity" };

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

    private static void ValidateRequiredFieldsForCreatePurchaseV2OkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "purchase", "profile" };

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

    private static void ValidateRequiredFieldsForListPurchasesOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "purchases" };

        // Nullable required fields - must be present but can be null
        var nullableRequiredFields = new[] { "afterCursor" };

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

        // Check nullable required fields (must be present but can be null)
        foreach (var field in nullableRequiredFields)
        {
            if (!root.TryGetProperty(field, out _))
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

    private static void ValidateRequiredFieldsForCreatePurchaseRequest(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "destination",
            "dataLimitInGB",
            "startDate",
            "endDate",
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

    private static void ValidateRequiredFieldsForCreatePurchaseOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "purchase", "profile" };

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

    private static void ValidateRequiredFieldsForTopUpEsimRequest(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "iccid", "dataLimitInGB" };

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

    private static void ValidateRequiredFieldsForTopUpEsimOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "purchase", "profile" };

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

    private static void ValidateRequiredFieldsForEditPurchaseRequest(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "purchaseId", "startDate", "endDate" };

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

    private static void ValidateRequiredFieldsForEditPurchaseOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "purchaseId" };

        // Nullable required fields - must be present but can be null
        var nullableRequiredFields = new[] { "newStartDate", "newEndDate" };

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

        // Check nullable required fields (must be present but can be null)
        foreach (var field in nullableRequiredFields)
        {
            if (!root.TryGetProperty(field, out _))
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

    private static void ValidateRequiredFieldsForGetPurchaseConsumptionOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "dataUsageRemainingInBytes",
            "dataUsageRemainingInGB",
            "status",
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

    private static void ValidateRequiredFieldsForGetEsimOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "esim" };

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

    private static void ValidateRequiredFieldsForGetEsimDeviceOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "device" };

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

    private static void ValidateRequiredFieldsForGetEsimHistoryOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "esim" };

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

    private static void ValidateRequiredFieldsForTokenOkResponse(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "token" };

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

    private static void ValidateRequiredFieldsForDestinations(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "name",
            "destination",
            "destinationISO2",
            "supportedCountries",
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

    private static void ValidateRequiredFieldsForPackages(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "id",
            "destination",
            "destinationISO2",
            "dataLimitInBytes",
            "dataLimitInGB",
            "minDays",
            "maxDays",
            "priceInCents",
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

    private static void ValidateRequiredFieldsForCreatePurchaseV2OkResponsePurchase(
        JsonElement root
    )
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "id", "packageId", "createdDate" };

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

    private static void ValidateRequiredFieldsForCreatePurchaseV2OkResponseProfile(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "iccid",
            "activationCode",
            "manualActivationCode",
            "iosActivationLink",
            "androidActivationLink",
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

    private static void ValidateRequiredFieldsForPurchases(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "id",
            "createdDate",
            "package",
            "esim",
            "source",
            "purchaseType",
        };

        // Nullable required fields - must be present but can be null
        var nullableRequiredFields = new[] { "startDate", "endDate" };

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

        // Check nullable required fields (must be present but can be null)
        foreach (var field in nullableRequiredFields)
        {
            if (!root.TryGetProperty(field, out _))
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

    private static void ValidateRequiredFieldsForPackage(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "id",
            "dataLimitInBytes",
            "dataLimitInGB",
            "destination",
            "destinationISO2",
            "destinationName",
            "priceInCents",
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

    private static void ValidateRequiredFieldsForPurchasesEsim(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "iccid" };

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

    private static void ValidateRequiredFieldsForCreatePurchaseOkResponsePurchase(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "id", "packageId", "createdDate" };

        // Nullable required fields - must be present but can be null
        var nullableRequiredFields = new[] { "startDate", "endDate" };

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

        // Check nullable required fields (must be present but can be null)
        foreach (var field in nullableRequiredFields)
        {
            if (!root.TryGetProperty(field, out _))
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

    private static void ValidateRequiredFieldsForCreatePurchaseOkResponseProfile(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "iccid", "activationCode", "manualActivationCode" };

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

    private static void ValidateRequiredFieldsForTopUpEsimOkResponsePurchase(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "id", "packageId", "createdDate" };

        // Nullable required fields - must be present but can be null
        var nullableRequiredFields = new[] { "startDate", "endDate" };

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

        // Check nullable required fields (must be present but can be null)
        foreach (var field in nullableRequiredFields)
        {
            if (!root.TryGetProperty(field, out _))
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

    private static void ValidateRequiredFieldsForTopUpEsimOkResponseProfile(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "iccid" };

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

    private static void ValidateRequiredFieldsForGetEsimOkResponseEsim(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[]
        {
            "iccid",
            "smdpAddress",
            "activationCode",
            "manualActivationCode",
            "status",
            "connectivityStatus",
            "isTopUpAllowed",
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

    private static void ValidateRequiredFieldsForDevice(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "oem", "hardwareName", "hardwareModel", "eid" };

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

    private static void ValidateRequiredFieldsForGetEsimHistoryOkResponseEsim(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "iccid", "history" };

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

    private static void ValidateRequiredFieldsForHistory(JsonElement root)
    {
        // Non-nullable required fields - must be present and not null
        var nonNullableRequiredFields = new[] { "status", "statusDate" };

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
