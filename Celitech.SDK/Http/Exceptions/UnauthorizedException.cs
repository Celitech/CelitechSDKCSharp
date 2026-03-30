using Celitech.SDK.Models;

namespace Celitech.SDK.Http.Exceptions;

public class UnauthorizedException : ApiException
{
    /// <summary>The error response associated with this exception.</summary>
    public Unauthorized Unauthorized { get; }

    /// <summary>
    /// Initializes a new instance of the UnauthorizedException class with an inner exception.
    /// </summary>
    /// <param name="unauthorized">The Unauthorized associated with this exception.</param>
    /// <param name="responseMessage">The HTTP response message.</param>
    public UnauthorizedException(Unauthorized unauthorized, HttpResponseMessage responseMessage)
        : base(responseMessage)
    {
        Unauthorized = unauthorized;
    }
}
