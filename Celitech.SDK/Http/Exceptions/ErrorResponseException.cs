using System.Net;
using Celitech.SDK.Models;

namespace Celitech.SDK.Http.Exceptions;

public class ErrorResponseException : ApiException
{
    /// <summary>The error response associated with this exception.</summary>
    public ErrorResponse ErrorResponse { get; }

    /// <summary>
    /// Initializes a new instance of the ErrorResponseException class.
    /// </summary>
    /// <param name="errorResponse">The ErrorResponse associated with this exception.</param>
    /// <param name="statusCode">The HTTP status code captured from the response.</param>
    /// <param name="body">The response body captured from the response.</param>
    /// <param name="headers">The response headers captured from the response.</param>
    public ErrorResponseException(
        ErrorResponse errorResponse,
        HttpStatusCode statusCode,
        string? body,
        IReadOnlyDictionary<string, string[]> headers
    )
        : base(statusCode, body, headers)
    {
        ErrorResponse = errorResponse;
    }
}
