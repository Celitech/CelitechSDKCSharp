using NUnit.Framework;

namespace Celitech.SDK.Tests;

/// <summary>
/// Round-trip coverage for <c>global::Celitech.SDK.EditPurchaseResponse</c>.
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
public class EditPurchaseResponseTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"purchaseId\":\"ae471106-c8b4-42cf-b83a-b061291f2922\",\"newStartDate\":\"2023-10-31T22:00:00.000Z\",\"newEndDate\":\"2023-11-20T21:59:59.000Z\",\"newStartTime\":4.68,\"newEndTime\":8.99}";

        var instance = TestJson.Deserialize<global::Celitech.SDK.EditPurchaseResponse>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::Celitech.SDK.EditPurchaseResponse did not round-trip."
        );
    }
}
