using System.Net;
using Celitech.SDK.Models;

namespace Celitech.SDK.Http.Exceptions;

public class UnauthorizedException : ApiException
{
    /// <summary>The error response associated with this exception.</summary>
    public Unauthorized Unauthorized { get; }

    /// <summary>
    /// Initializes a new instance of the UnauthorizedException class.
    /// </summary>
    /// <param name="unauthorized">The Unauthorized associated with this exception.</param>
    /// <param name="statusCode">The HTTP status code captured from the response.</param>
    /// <param name="body">The response body captured from the response.</param>
    /// <param name="headers">The response headers captured from the response.</param>
    public UnauthorizedException(
        Unauthorized unauthorized,
        HttpStatusCode statusCode,
        string? body,
        IReadOnlyDictionary<string, string[]> headers
    )
        : base(statusCode, body, headers)
    {
        Unauthorized = unauthorized;
    }
}
