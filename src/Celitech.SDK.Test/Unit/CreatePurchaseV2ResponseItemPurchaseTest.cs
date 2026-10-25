using NUnit.Framework;

namespace Celitech.SDK.Tests;

/// <summary>
/// Round-trip coverage for <c>global::Celitech.SDK.CreatePurchaseV2ResponseItemPurchase</c>.
/// </summary>
/// <remarks>
/// Asserts the wire document the model was built from comes back out of it unchanged — not merely
/// that serialization runs. Starting from JSON rather than from a constructed instance is what
/// makes one emitter cover both output modes: the legacy positional record and the fernMode
/// `required`/`init` record are constructed differently but deserialize from the same document, so
/// nothing here has to know which shape it is looking at. It is also the stronger assertion, since
/// a property whose C# name diverges from its wire name fails this and would pass a test that only
/// compared an instance to itself.
/// </remarks>
[TestFixture]
public class CreatePurchaseV2ResponseItemPurchaseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"id\":\"1b97b67a-f4ea-45ff-bbc1-8f424b1418c4\",\"packageId\":\"6cf19d46-b545-4029-a46b-cdeba22b6957\",\"createdDate\":\"2023-10-20T00:00:00.000Z\"}";

        var instance =
            TestJson.Deserialize<global::Celitech.SDK.CreatePurchaseV2ResponseItemPurchase>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::Celitech.SDK.CreatePurchaseV2ResponseItemPurchase did not round-trip."
        );
    }
}
