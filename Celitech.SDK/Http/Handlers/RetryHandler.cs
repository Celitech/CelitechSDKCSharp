using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Celitech.SDK.Config;
using Polly;
using Polly.Retry;

namespace Celitech.SDK.Http.Handlers;

/// <summary>
/// A handler for retrying requests when they fail.
/// </summary>
public class RetryHandler : DelegatingHandler
{
    private static readonly HttpRequestOptionsKey<RetryConfig> RetryConfigKey =
        new HttpRequestOptionsKey<RetryConfig>("_RequestConfig_RetryConfig");

    private readonly int _defaultMaxRetryAttempts = 3;
    private readonly TimeSpan _defaultDelay = TimeSpan.FromMilliseconds(150);
    private readonly TimeSpan _defaultMaxDelay = TimeSpan.FromMilliseconds(5000);
    private readonly TimeSpan _defaultMaxRetryAfterDelay = TimeSpan.FromMilliseconds(60000);
    private readonly double _defaultBackoffMultiplier = 2;
    private readonly bool _defaultUseJitter = true;
    private readonly HashSet<string> _defaultRetryableHttpMethods = new HashSet<string>(
        StringComparer.OrdinalIgnoreCase
    )
    {
        "GET",
        "POST",
        "PUT",
        "DELETE",
        "PATCH",
        "HEAD",
        "OPTIONS",
    };

    private readonly ResiliencePipeline<HttpResponseMessage> _defaultPipeline;
    private readonly ConcurrentDictionary<
        RetryConfig,
        ResiliencePipeline<HttpResponseMessage>
    > _pipelineCache = new();

    public RetryHandler(HttpMessageHandler? innerHandler = null)
        : base(innerHandler ?? Client.CreateDefaultTransport())
    {
        _defaultPipeline = BuildPipeline(null);
    }

    private static bool ShouldRetryStatus(HttpStatusCode statusCode, HashSet<int>? specificCodes)
    {
        if (specificCodes != null)
            return specificCodes.Contains((int)statusCode);

        return (int)statusCode >= 500
            || statusCode == HttpStatusCode.RequestTimeout
            || statusCode == HttpStatusCode.TooManyRequests;
    }

    private static readonly Regex DeltaSecondsRegex = new(@"^\d+(\.\d+)?$", RegexOptions.Compiled);

    /// <summary>
    /// Returns the server-directed retry delay from rate-limit response headers, honoring
    /// Retry-After (delta-seconds or HTTP-date) and, when absent, X-RateLimit-Reset (epoch
    /// seconds), clamped to <paramref name="maxCap"/>. Returns null when no usable header is
    /// present so the caller falls back to the computed exponential backoff.
    /// </summary>
    private static TimeSpan? GetRetryAfterDelay(HttpResponseMessage? response, TimeSpan maxCap)
    {
        if (response is null || maxCap <= TimeSpan.Zero)
            return null;

        // retry-after-ms (milliseconds) is a non-standard but finer-grained hint some APIs send
        // (e.g. OpenAI); it takes precedence over the whole-second Retry-After.
        var retryAfterMs = response.Headers.TryGetValues(
            "Retry-After-Ms",
            out var retryAfterMsValues
        )
            ? retryAfterMsValues.FirstOrDefault()?.Trim()
            : null;
        // The strict delta format rules out negatives/NaN; a huge value parses to
        // +Infinity and Math.Min clamps it to the cap (parity with the other SDKs).
        if (
            !string.IsNullOrEmpty(retryAfterMs)
            && DeltaSecondsRegex.IsMatch(retryAfterMs)
            && double.TryParse(
                retryAfterMs,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out var ms
            )
        )
        {
            return TimeSpan.FromMilliseconds(Math.Min(ms, maxCap.TotalMilliseconds));
        }

        double? seconds = null;
        if (response.Headers.TryGetValues("Retry-After", out var retryAfterValues))
            seconds = ParseRetryAfter(retryAfterValues.FirstOrDefault());

        // X-RateLimit-Reset (epoch seconds) is only consulted when Retry-After is absent.
        // An already-elapsed reset window is treated as stale (fall back to backoff), whereas
        // an elapsed Retry-After above resolves to 0 ("retry now") — this mirrors the Ruby SDK.
        if (
            seconds is null
            && response.Headers.TryGetValues("X-RateLimit-Reset", out var resetValues)
            && long.TryParse(
                resetValues.FirstOrDefault(),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var epoch
            )
        )
        {
            var delta = (
                DateTimeOffset.FromUnixTimeSeconds(epoch) - DateTimeOffset.UtcNow
            ).TotalSeconds;
            if (delta > 0)
                seconds = delta;
        }

        if (seconds is null)
            return null;

        var clampedSeconds = Math.Clamp(seconds.Value, 0.0, maxCap.TotalSeconds);
        return TimeSpan.FromSeconds(clampedSeconds);
    }

    /// <summary>
    /// Parses a Retry-After header value: integer/float delta-seconds, or an HTTP-date
    /// (a past date yields 0). Returns the delay in seconds, or null if unparseable.
    /// </summary>
    private static double? ParseRetryAfter(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var trimmed = value.Trim();
        if (DeltaSecondsRegex.IsMatch(trimmed))
            return double.Parse(trimmed, CultureInfo.InvariantCulture);

        if (
            DateTimeOffset.TryParse(
                trimmed,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out var date
            )
        )
        {
            var delta = (date - DateTimeOffset.UtcNow).TotalSeconds;
            return delta > 0 ? delta : 0.0;
        }

        return null;
    }

    private ResiliencePipeline<HttpResponseMessage> BuildPipeline(RetryConfig? overrideConfig)
    {
        var maxRetryAttempts = overrideConfig?.MaxRetryAttempts ?? _defaultMaxRetryAttempts;
        var delay = overrideConfig?.Delay ?? _defaultDelay;
        var maxDelay = overrideConfig?.MaxDelay ?? _defaultMaxDelay;
        var maxRetryAfterDelay = overrideConfig?.MaxRetryAfterDelay ?? _defaultMaxRetryAfterDelay;
        var backoffMultiplier = overrideConfig?.BackoffMultiplier ?? _defaultBackoffMultiplier;
        var useJitter = overrideConfig?.UseJitter ?? _defaultUseJitter;
        HashSet<int>? specificCodes =
            overrideConfig?.RetryableStatusCodes != null
                ? new HashSet<int>(overrideConfig.RetryableStatusCodes)
                : null;

        return new ResiliencePipelineBuilder<HttpResponseMessage>()
            .AddRetry(
                new RetryStrategyOptions<HttpResponseMessage>()
                {
                    MaxRetryAttempts = maxRetryAttempts,
                    ShouldHandle = (args) =>
                    {
                        var response = args.Outcome.Result;
                        if (response is null)
                            return ValueTask.FromResult(false);
                        return ValueTask.FromResult(
                            ShouldRetryStatus(response.StatusCode, specificCodes)
                        );
                    },
                    DelayGenerator = (args) =>
                    {
                        var headerDelay = GetRetryAfterDelay(
                            args.Outcome.Result,
                            maxRetryAfterDelay
                        );
                        if (headerDelay is not null)
                            return new ValueTask<TimeSpan?>(headerDelay);

                        var exponentialMs =
                            delay.TotalMilliseconds
                            * Math.Pow(backoffMultiplier, args.AttemptNumber);
                        if (useJitter)
                        {
                            var jitterFactor = 1.0 + (Random.Shared.NextDouble() - 0.5) * 0.5;
                            exponentialMs *= jitterFactor;
                        }
                        var cappedMs = Math.Min(exponentialMs, maxDelay.TotalMilliseconds);
                        return new ValueTask<TimeSpan?>(TimeSpan.FromMilliseconds(cappedMs));
                    },
                }
            )
            .Build();
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        request.Options.TryGetValue(RetryConfigKey, out var retryConfig);

        var retryableHttpMethods =
            retryConfig?.RetryableHttpMethods != null
                ? new HashSet<string>(
                    retryConfig.RetryableHttpMethods,
                    StringComparer.OrdinalIgnoreCase
                )
                : _defaultRetryableHttpMethods;

        if (!retryableHttpMethods.Contains(request.Method.Method))
        {
            return await base.SendAsync(request, cancellationToken);
        }

        if (retryConfig?.MaxRetryAttempts == 0)
        {
            return await base.SendAsync(request, cancellationToken);
        }

        var pipeline = retryConfig is null
            ? _defaultPipeline
            : _pipelineCache.GetOrAdd(retryConfig, BuildPipeline);
        return await pipeline.ExecuteAsync<HttpResponseMessage>(
            async (token) => await base.SendAsync(request, token),
            cancellationToken
        );
    }
}
