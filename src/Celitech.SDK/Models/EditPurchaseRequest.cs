using Celitech.SDK;
using Celitech.SDK.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK.Purchases;

[Serializable]
public record EditPurchaseRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the purchase</value>
    [JsonPropertyName("purchaseId")]
    public required string PurchaseId { get; set; }

    /// <value>Start date of the package's validity in the format 'yyyy-MM-dd'. This date can be set to the current day or any day within the next 12 months.</value>
    [JsonPropertyName("startDate")]
    public required DateOnly StartDate { get; set; }

    /// <value>End date of the package's validity in the format 'yyyy-MM-dd'. End date can be maximum 90 days after Start date.</value>
    [JsonPropertyName("endDate")]
    public required DateOnly EndDate { get; set; }

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
    public virtual bool Equals(EditPurchaseRequest? other)
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
            && ValueEquality.AreEqual(PurchaseId, other.PurchaseId)
            && ValueEquality.AreEqual(StartDate, other.StartDate)
            && ValueEquality.AreEqual(EndDate, other.EndDate)
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
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PurchaseId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(StartDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(EndDate);
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
