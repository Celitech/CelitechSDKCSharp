using global::System.Text;

namespace Celitech.SDK.Core;

internal static class EncodingCache
{
    internal static readonly Encoding Utf8NoBom = new UTF8Encoding(
        encoderShouldEmitUTF8Identifier: false,
        throwOnInvalidBytes: true
    );
}
