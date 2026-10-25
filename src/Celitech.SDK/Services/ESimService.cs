using System.Net.Http.Json;
using Celitech.SDK;
using Celitech.SDK.Config;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Handlers;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Purchases;

namespace Celitech.SDK.Services;

/// <summary>
/// Service class providing access to API endpoints for ESimService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
internal class ESimService : BaseService
{
    private RequestConfig? _getEsimAsyncConfig;
    private RequestConfig? _getEsimDeviceAsyncConfig;
    private RequestConfig? _getEsimHistoryAsyncConfig;
    private RequestConfig? _suspendEsimAsyncConfig;

    internal ESimService(global::Celitech.SDK.Http.Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ESimService SetGetEsimAsyncConfig(RequestConfig config)
    {
        _getEsimAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimDeviceAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ESimService SetGetEsimDeviceAsyncConfig(RequestConfig config)
    {
        _getEsimDeviceAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>GetEsimHistoryAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ESimService SetGetEsimHistoryAsyncConfig(RequestConfig config)
    {
        _getEsimHistoryAsyncConfig = config;
        return this;
    }

    /// <summary>
    /// Sets method-level configuration for <c>SuspendEsimAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public ESimService SetSuspendEsimAsyncConfig(RequestConfig config)
    {
        _suspendEsimAsyncConfig = config;
        return this;
    }

    /// <summary>Get eSIM</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.GetEsimResponse> GetEsimAsync(
        string iccid,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (iccid is null)
            throw new ArgumentNullException(nameof(iccid));

        var resolvedConfig = GetResolvedConfig(_getEsimAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "esim")
            .SetOptionalQueryParameter("iccid", iccid)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::Celitech.SDK.GetEsimResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.GetEsimResponse>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new Celitech.SDK.CelitechClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: Celitech.SDK.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get eSIM Device</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.GetEsimDeviceResponse> GetEsimDeviceAsync(
        string iccid,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (iccid is null)
            throw new ArgumentNullException(nameof(iccid));

        var resolvedConfig = GetResolvedConfig(_getEsimDeviceAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "esim/{iccid}/device")
            .SetPathParameter("iccid", iccid)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::Celitech.SDK.GetEsimDeviceResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.GetEsimDeviceResponse>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new Celitech.SDK.CelitechClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: Celitech.SDK.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Get eSIM History</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.GetEsimHistoryResponse> GetEsimHistoryAsync(
        string iccid,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (iccid is null)
            throw new ArgumentNullException(nameof(iccid));

        var resolvedConfig = GetResolvedConfig(_getEsimHistoryAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "esim/{iccid}/history")
            .SetPathParameter("iccid", iccid)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::Celitech.SDK.GetEsimHistoryResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.GetEsimHistoryResponse>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new Celitech.SDK.CelitechClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: Celitech.SDK.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }

    /// <summary>Suspends an eSIM to prevent abuse. All of the eSIM's packages are terminated and its connectivity is switched off. The eSIM is not refunded: the charge stays.</summary>
    /// <param name="iccid">ID of the eSIM</param>
    /// <param name="idempotencyKey">Optional. A unique value (for example a UUID) that makes this request safe to retry. If a request with the same `Idempotency-Key` and the same body succeeds, repeating it returns the original response instead of performing the action again, and the response includes the header `Idempotent-Replayed: true`. Keys are scoped to your credentials and remembered for 3 days. Only successful (2xx) responses are remembered, so a request that failed can be retried with the same key. Reusing a key with a different request returns `422`; sending it while the original request is still being processed returns `409`. If the idempotency store is temporarily unavailable, the request is not processed and returns `503`; retry it. Must be 1 to 255 printable ASCII characters, without spaces.</param>
    public async global::System.Threading.Tasks.Task<global::Celitech.SDK.SuspendEsimResponse> SuspendEsimAsync(
        string iccid,
        string? idempotencyKey = null,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        if (iccid is null)
            throw new ArgumentNullException(nameof(iccid));

        var resolvedConfig = GetResolvedConfig(_suspendEsimAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "esim/{iccid}/suspend")
            .SetPathParameter("iccid", iccid)
            .SetOptionalHeader("Idempotency-Key", idempotencyKey)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Standard deserialization
        // Read the body first so a decode failure can report the bytes that caused it.
        var responseBody = await response
            .Content
#if NET5_0_OR_GREATER
            .ReadAsStringAsync(cancellationToken)
#else
        .ReadAsStringAsync()
#endif
            .ConfigureAwait(false);
        global::Celitech.SDK.SuspendEsimResponse result;
        try
        {
            result =
                global::System.Text.Json.JsonSerializer.Deserialize<global::Celitech.SDK.SuspendEsimResponse>(
                    responseBody,
                    _jsonSerializerOptions
                )!;
        }
        catch (global::System.Text.Json.JsonException exception)
        {
            throw new Celitech.SDK.CelitechClientApiException(
                "Failed to deserialize response",
                (int)response.StatusCode,
                responseBody,
                exception,
                rawResponse: Celitech.SDK.Core.RawResponseFactory.FromHttpResponseMessage(response)
            );
        }

        return result;
    }
}
