namespace Celitech.SDK;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnprocessableEntityError(
    Celitech.SDK.ErrorResponse body,
    Celitech.SDK.RawResponse? rawResponse = null
) : CelitechClientApiException("UnprocessableEntityError", 422, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Celitech.SDK.ErrorResponse Body { get; } = body;
}
