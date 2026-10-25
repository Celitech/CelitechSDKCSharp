using NUnit.Framework;

namespace Celitech.SDK.Tests;

/// <summary>
/// Round-trip coverage for <c>global::Celitech.SDK.GetEsimHistoryResponseEsim</c>.
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
public class GetEsimHistoryResponseEsimTest
{
    [Test]
    public void RoundTripsThroughTheWireDocument()
    {
        const string wire =
            "{\"iccid\":\"1111222233334444555000\",\"history\":[{\"status\":\"INSTALLED\",\"statusDate\":\"2023-10-20T00:00:00.000Z\",\"date\":8.75}]}";

        var instance = TestJson.Deserialize<global::Celitech.SDK.GetEsimHistoryResponseEsim>(wire);
        var serialized = TestJson.Serialize(instance);

        JsonAssert.AreEquivalent(
            wire,
            serialized,
            "global::Celitech.SDK.GetEsimHistoryResponseEsim did not round-trip."
        );
    }
}
