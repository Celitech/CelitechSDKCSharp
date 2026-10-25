using System.Net;
using System.Text;

namespace Celitech.SDK.Http.Exceptions;

/// <summary>
/// fernMode error gateway. Builds and throws Fern's <see cref="Celitech.SDK.CelitechClientApiException"/>
/// from a failed response so consumers catch the Fern exception type. Captures the status code, URL,
/// body, and a detached header snapshot, then disposes the live response (no live response is exposed).
/// When a status maps to one of Fern's status-named subclasses (<c>NotFoundError</c>/etc.) it raises
/// that subclass with the deserialized (typed or <c>object</c>) body, falling back to the base
/// exception with the raw body when the body cannot be deserialized (FSM-176).
/// </summary>
internal static class FernApiExceptionFactory
{
    internal static async Task<Celitech.SDK.CelitechClientApiException> FromResponseAsync(
        HttpResponseMessage response,
        string? message = null
    )
    {
        var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var statusCode = response.StatusCode;
        var url = response.RequestMessage?.RequestUri ?? new Uri("about:blank");
        // Snapshot the headers before disposing so the RawResponse holds no live response.
        var headers = response
            .Headers.Concat(response.Content.Headers)
            .GroupBy(header => header.Key, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                group => group.Key,
                group => group.Last().Value.ToArray(),
                StringComparer.OrdinalIgnoreCase
            );
        response.Dispose();

        // Share the success-path construction (FSM-189): re-buffer the snapshotted status/body/headers
        // into a detached response, then build the same RawResponse shape, overriding the URL with the
        // original request URL (the detached copy has no RequestMessage).
        var rawResponse = Celitech.SDK.Core.RawResponseFactory.FromHttpResponseMessage(
            BuildBufferedResponse(statusCode, body, headers),
            url
        );

        // Raise Fern's status-named subclass with its (typed) body; on a body that cannot be mapped
        // to the declared type, fall through to the base exception with the raw body.
        try
        {
            switch ((int)statusCode)
            {
                case 400:
                    return new Celitech.SDK.BadRequestError(
                        Celitech.SDK.Core.JsonUtils.Deserialize<Celitech.SDK.ErrorResponse>(body),
                        rawResponse: rawResponse
                    );
                case 401:
                    return new Celitech.SDK.UnauthorizedError(
                        Celitech.SDK.Core.JsonUtils.Deserialize<Celitech.SDK.ErrorResponse>(body),
                        rawResponse: rawResponse
                    );
                case 409:
                    return new Celitech.SDK.ConflictError(
                        Celitech.SDK.Core.JsonUtils.Deserialize<Celitech.SDK.ErrorResponse>(body),
                        rawResponse: rawResponse
                    );
                case 422:
                    return new Celitech.SDK.UnprocessableEntityError(
                        Celitech.SDK.Core.JsonUtils.Deserialize<Celitech.SDK.ErrorResponse>(body),
                        rawResponse: rawResponse
                    );
                case 503:
                    return new Celitech.SDK.ServiceUnavailableError(
                        Celitech.SDK.Core.JsonUtils.Deserialize<Celitech.SDK.ErrorResponse>(body),
                        rawResponse: rawResponse
                    );
            }
        }
        catch (System.Text.Json.JsonException)
        {
            // Unable to map the error body to the declared type; fall through to the base exception.
        }

        return new Celitech.SDK.CelitechClientApiException(
            message ?? $"Error with status code {(int)statusCode}",
            (int)statusCode,
            body,
            null,
            rawResponse
        );
    }

    private static HttpResponseMessage BuildBufferedResponse(
        HttpStatusCode statusCode,
        string body,
        IReadOnlyDictionary<string, string[]> headers
    )
    {
        var content = new ByteArrayContent(Encoding.UTF8.GetBytes(body));
        var buffered = new HttpResponseMessage(statusCode) { Content = content };
        foreach (var header in headers)
        {
            // Response headers reject content headers (e.g. Content-Type); fall back to content headers.
            if (!buffered.Headers.TryAddWithoutValidation(header.Key, header.Value))
            {
                content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
        return buffered;
    }
}
