using System.Text.Json;
using Celitech.SDK.Config;
using Celitech.SDK.Http.Exceptions;

namespace Celitech.SDK.Http;

public class Client
{
    private HttpClient _httpClient;

    /// <summary>
    /// Builds the default transport handler. A <see cref="SocketsHttpHandler"/> is used so pooled
    /// connections are recycled (picking up DNS changes on long-lived clients) and gzip/deflate/brotli
    /// responses are transparently decompressed.
    /// </summary>
    internal static SocketsHttpHandler CreateDefaultTransport()
    {
        return new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2),
            AutomaticDecompression = System.Net.DecompressionMethods.All,
        };
    }

    public Client(
        CelitechConfig config,
        HttpMessageHandler? handler = null,
        bool disposeHandler = true
    )
    {
        _httpClient =
            handler == null
                ? new HttpClient(CreateDefaultTransport())
                : new HttpClient(handler, disposeHandler);
        _httpClient.BaseAddress = config?.Environment?.Uri ?? Environment.Default.Uri;
        _httpClient.DefaultRequestHeaders.Add(
            "user-agent",
            "postman-codegen/2.1.0 Celitech.SDK/2.0.6 (csharp)"
        );
    }

    public void SetBaseAddress(Uri uri)
    {
        _httpClient.BaseAddress = uri;
    }

    public void SetTimeout(TimeSpan timeout)
    {
        _httpClient.Timeout = timeout;
    }

    public async Task<HttpResponseMessage> SendAsync(
        Request request,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _httpClient
            .SendAsync(request.HttpRequestMessage, cancellationToken)
            .ConfigureAwait(false);
        await HandleError(request, response).ConfigureAwait(false);
        return response;
    }

    public async Task<HttpResponseMessage> SendAsync(
        Request request,
        HttpCompletionOption httpCompletionOptions,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _httpClient
            .SendAsync(request.HttpRequestMessage, httpCompletionOptions, cancellationToken)
            .ConfigureAwait(false);
        await HandleError(request, response).ConfigureAwait(false);
        return response;
    }

    /// <summary>
    /// Handles error responses by checking configured error mappings and throwing appropriate exceptions.
    /// </summary>
    /// <param name="response">The HTTP response message to check for errors.</param>
    /// <exception cref="HttpRequestException">Thrown when the request fails and no matching error mapping is found, or when deserialization fails.</exception>
    /// <exception cref="Exception">Throws a specific exception type based on configured error mappings when a matching status code and content type is found.</exception>
    private async Task HandleError(Request request, HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return; // No error to handle
        }

        var statusCode = (int)response.StatusCode;
        var contentType = response.Content.Headers.ContentType?.MediaType ?? string.Empty;

        var mapping = request.ErrorMappings?.FirstOrDefault(m =>
            m.StatusCode == statusCode && ContentTypes.Matches(m.ContentType, contentType)
        );

        if (mapping != null)
        {
            await DeserializeAndThrowException(response, mapping).ConfigureAwait(false);
        }

        if (request.DefaultErrorMapping != null)
        {
            await DeserializeAndThrowException(response, request.DefaultErrorMapping)
                .ConfigureAwait(false);
        }

        throw await ApiException.FromResponseAsync(response).ConfigureAwait(false);
    }

    /// <summary>
    /// Deserializes a given exception and throws it
    /// </summary>
    /// <param name="response">The HTTP response message to check for errors.</param>
    /// <param name="mapping">The error mapping to use for deserialization and exception creation.</param>
    /// <exception cref="Exception">Throws a specific exception type based on the provided error mapping.</exception>
    private async Task DeserializeAndThrowException(
        HttpResponseMessage response,
        ErrorMapping mapping
    )
    {
        // TODO USE DESERIALIZATION LOGIC which will catch the case where we have non-json responses
        var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var (statusCode, headers) = ApiException.CaptureAndDispose(response);
        try
        {
            var deserializedError = JsonSerializer.Deserialize(contentString, mapping.TargetType);

            if (deserializedError == null)
            {
                throw new ApiException(statusCode, contentString, headers);
            }
            var exception = (Exception)
                Activator.CreateInstance(
                    mapping.ExceptionType,
                    new object[] { deserializedError, statusCode, contentString, headers }
                )!;
            throw exception;
        }
        catch (JsonException)
        {
            throw new ApiException(statusCode, contentString, headers);
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
