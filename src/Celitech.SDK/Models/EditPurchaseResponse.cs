using Celitech.SDK.Core;
using Celitech.SDK.Purchases;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Celitech.SDK;

[Serializable]
public record EditPurchaseResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <value>ID of the purchase</value>
    [JsonPropertyName("purchaseId")]
    public required string PurchaseId { get; set; }

    /// <value>Start date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [JsonPropertyName("newStartDate")]
    public DateTime? NewStartDate { get; set; }

    /// <value>End date of the package's validity in the format 'yyyy-MM-ddThh:mm:ssZZ'</value>
    [JsonPropertyName("newEndDate")]
    public DateTime? NewEndDate { get; set; }

    /// <value>Epoch value representing the new start time of the package's validity</value>
    [JsonPropertyName("newStartTime")]
    public double? NewStartTime { get; set; }

    /// <value>Epoch value representing the new end time of the package's validity</value>
    [JsonPropertyName("newEndTime")]
    public double? NewEndTime { get; set; }

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
    public virtual bool Equals(EditPurchaseResponse? other)
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
            && ValueEquality.AreEqual(NewStartDate, other.NewStartDate)
            && ValueEquality.AreEqual(NewEndDate, other.NewEndDate)
            && ValueEquality.AreEqual(NewStartTime, other.NewStartTime)
            && ValueEquality.AreEqual(NewEndTime, other.NewEndTime)
            && AdditionalProperties.Equals(other.AdditionalProperties);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(PurchaseId);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NewStartDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NewEndDate);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NewStartTime);
            hash = (hash * 31) + ValueEquality.GetHashCodeOf(NewEndTime);
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
