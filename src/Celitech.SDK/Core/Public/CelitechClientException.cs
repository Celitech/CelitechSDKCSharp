namespace Celitech.SDK;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class CelitechClientException(string message, Exception? innerException = null)
    : Exception(message, innerException);
