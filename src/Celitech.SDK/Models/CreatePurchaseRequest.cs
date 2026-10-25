using Celitech.SDK;
using Celitech.SDK.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK.Purchases;

[Serializable]
public record CreatePurchaseRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ISO representation of the package's destination. Supports both ISO2 (e.g., 'FR') and ISO3 (e.g., 'FRA') country codes.</value>
    [JsonPropertyName("destination")]
    public required string Destination { get; set; }

    /// <value>Size of the package in GB. The available options are 0.5, 1, 2, 3, 5, 8, 20, 50GB. Use `-1` to purchase an unlimited (date-based) package — provide `startDate`/`endDate` spanning 3 to 30 days.</value>
    [JsonPropertyName("dataLimitInGB")]
    public required double DataLimitInGb { get; set; }

    /// <value>Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.</value>
    [JsonPropertyName("startDate")]
    public required DateOnly StartDate { get; set; }

    /// <value>End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.</value>
    [JsonPropertyName("endDate")]
    public required DateOnly EndDate { get; set; }

    /// <value>Email address where the purchase confirmation email will be sent (including QR Code &amp; activation steps)</value>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <value>An identifier provided by the partner to link this purchase to their booking or transaction for analytics and debugging purposes. Letters, digits, `-`, `_`, `.`, `@` and `+` are allowed (so an email address works), up to 255 characters.</value>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }

    /// <value>Customize the network brand of the issued eSIM. The `networkBrand` parameter cannot exceed 15 characters in length and must contain only letters, numbers, dots (.), ampersands (&amp;), and spaces. This feature is available to platforms with Diamond tier only.</value>
    [JsonPropertyName("networkBrand")]
    public string? NetworkBrand { get; set; }

    /// <value>Customize the email subject brand. The `emailBrand` parameter cannot exceed 25 characters in length and must contain only letters, numbers, and spaces. This feature is available to platforms with Diamond tier only.</value>
    [JsonPropertyName("emailBrand")]
    public string? EmailBrand { get; set; }

    /// <value>Language of the confirmation email sent to the customer.</value>
    [JsonPropertyName("language")]
    public CreatePurchaseRequestLanguage? Language { get; set; }

    /// <value>Epoch value representing the start time of the package's validity. This timestamp can be set to the current time or any time within the next 12 months.</value>
    [JsonPropertyName("startTime")]
    public double? StartTime { get; set; }

    /// <value>Epoch value representing the end time of the package's validity. End time can be maximum 90 days after Start time.</value>
    [JsonPropertyName("endTime")]
    public double? EndTime { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    /// <remarks>
    /// Written out rather than synthesized. A record's generated Equals compares every instance
    /// field, and `_extensionData` is a fresh Dictionary per instance compared by REFERENCE, so two
    /// identical models were never equal — silently defeating ==, Distinct(), HashSet membership,
    /// dictionary keys and test assertions for every model in the SDK. Excluding it loses nothing:
    /// it is a transient deserialization sink whose contents are copied into
    /// AdditionalProperties, which IS compared here.
    /// </remarks>
    public virtual bool Equals(CreatePurchaseRequest? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // The synthesized record Equals compares EqualityContract, so a base instance never equals a
        // derived one. Hand-writing Equals drops that unless it is restated.
        if (EqualityContract != other.EqualityContract)
        {
            return false;
        }
        // Declared properties first: the additional-properties comparison walks a dictionary and
        // allocates a string per entry, and is the least likely of the three to differ, so letting
        // the cheap scalar comparisons short-circuit ahead of it matters for Distinct/HashSet over
        // large collections. Anchored on `true` so a model with no declared properties still emits
        // a valid expression.
        return true
            && ValueEquality.AreEqual(Destination, other.Destination)
            && ValueEquality.AreEqual(DataLimitInGb, other.DataLimitInGb)
            && ValueEquality.AreEqual(StartDate, other.StartDate)
            && ValueEquality.AreEqual(EndDate, other.EndDate)
            && ValueEquality.AreEqual(Email, other.Email)
            && ValueEquality.AreEqual(ReferenceId, other.ReferenceId)
            && ValueEquality.AreEqual(NetworkBrand, other.NetworkBrand)
            && ValueEquality.AreEqual(EmailBrand, other.EmailBrand)
            && ValueEquality.AreEqual(Language, other.Language)
            && ValueEquality.AreEqual(StartTime, other.StartTime)
            && ValueEquality.AreEqual(EndTime, other.EndTime)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Destination);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(DataLimitInGb);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Email);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(ReferenceId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NetworkBrand);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EmailBrand);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(Language);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndTime);
            hash = (hash * 31) + AdditionalProperties.GetHashCode();
            return hash;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
