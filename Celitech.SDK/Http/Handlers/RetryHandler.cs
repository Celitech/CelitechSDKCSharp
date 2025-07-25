using System.Net;
using Polly;
using Polly.Retry;

namespace Celitech.SDK.Http.Handlers;

/// <summary>
/// A handler for retrying requests when they fail.
/// </summary>
public class RetryHandler : DelegatingHandler
{
    public RetryHandler(HttpMessageHandler? innerHandler = null)
        : base(innerHandler ?? new HttpClientHandler()) { }

    private static readonly Func<
        RetryPredicateArguments<HttpResponseMessage>,
        ValueTask<bool>
    > TransientHttpStatusCodePredicate = (args) =>
    {
        var response = args.Outcome.Result;

        if (response is null)
        {
            return ValueTask.FromResult(false);
        }

        var isTransientStatusCode =
            (int)response.StatusCode >= 500 || response.StatusCode == HttpStatusCode.RequestTimeout;
        return ValueTask.FromResult(isTransientStatusCode);
    };

    private readonly ResiliencePipeline<HttpResponseMessage> _pipeline =
        new ResiliencePipelineBuilder<HttpResponseMessage>()
            .AddRetry(
                new RetryStrategyOptions<HttpResponseMessage>()
                {
                    ShouldHandle = TransientHttpStatusCodePredicate,
                    Delay = TimeSpan.FromMilliseconds(150),
                    BackoffType = DelayBackoffType.Exponential,
                    MaxRetryAttempts = 3,
                }
            )
            .Build();

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        return await _pipeline.ExecuteAsync<HttpResponseMessage>(
            async (token) => await base.SendAsync(request, token),
            cancellationToken
        );
    }
}
