using Celitech.SDK.Models;

namespace Celitech.SDK.Http.Exceptions;

public class BadRequestException : ApiException
{
    /// <summary>The error response associated with this exception.</summary>
    public BadRequest BadRequest { get; }

    /// <summary>
    /// Initializes a new instance of the BadRequestException class with an inner exception.
    /// </summary>
    /// <param name="badRequest">The BadRequest associated with this exception.</param>
    /// <param name="responseMessage">The HTTP response message.</param>
    public BadRequestException(BadRequest badRequest, HttpResponseMessage responseMessage)
        : base(responseMessage)
    {
        BadRequest = badRequest;
    }
}
