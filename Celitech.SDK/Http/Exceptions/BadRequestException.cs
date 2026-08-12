using System.Net;
using Celitech.SDK.Models;

namespace Celitech.SDK.Http.Exceptions;

public class BadRequestException : ApiException
{
    /// <summary>The error response associated with this exception.</summary>
    public BadRequest BadRequest { get; }

    /// <summary>
    /// Initializes a new instance of the BadRequestException class.
    /// </summary>
    /// <param name="badRequest">The BadRequest associated with this exception.</param>
    /// <param name="statusCode">The HTTP status code captured from the response.</param>
    /// <param name="body">The response body captured from the response.</param>
    /// <param name="headers">The response headers captured from the response.</param>
    public BadRequestException(
        BadRequest badRequest,
        HttpStatusCode statusCode,
        string? body,
        IReadOnlyDictionary<string, string[]> headers
    )
        : base(statusCode, body, headers)
    {
        BadRequest = badRequest;
    }
}
