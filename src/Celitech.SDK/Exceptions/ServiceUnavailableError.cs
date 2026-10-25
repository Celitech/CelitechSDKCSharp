namespace Celitech.SDK;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ServiceUnavailableError(
    Celitech.SDK.ErrorResponse body,
    Celitech.SDK.RawResponse? rawResponse = null
) : CelitechClientApiException("ServiceUnavailableError", 503, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Celitech.SDK.ErrorResponse Body { get; } = body;
}
