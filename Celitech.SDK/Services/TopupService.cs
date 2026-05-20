using System.Net.Http.Json;
using Celitech.SDK.Config;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Handlers;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Models;
using Celitech.SDK.Validation;
using Celitech.SDK.Validation.Extensions;

namespace Celitech.SDK.Services;

/// <summary>
/// Service class providing access to API endpoints for TopupService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class TopupService : BaseService
{
    private RequestConfig? _topUpESimAsyncConfig;

    internal TopupService(Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>TopUpESimAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public TopupService SetTopUpESimAsyncConfig(RequestConfig config)
    {
        _topUpESimAsyncConfig = config;
        return this;
    }

    /// <summary>This endpoint is used to top-up an existing eSIM with the previously associated destination by providing its ICCID and package details. To determine if an eSIM can be topped up, use the Get eSIM endpoint, which returns the `isTopUpAllowed` flag.</summary>
    public async Task<object> TopUpESimAsync(
        TopUpESimRequest? input,
        string? accept,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var acceptValidationResult = new StringValidator().ValidateRequired<string>(accept);
        if (acceptValidationResult != null)
        {
            validationResults.Add(acceptValidationResult);
        }
        ;
        var validator = new TopUpESimRequestValidator();
        var validationResult = validator.Validate(input);
        validationResults.Add(validationResult);

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_topUpESimAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "purchases/topup")
            .SetHeader("Accept", accept)
            .SetContentAsJson(input, _jsonSerializerOptions)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result = DeserializationValidation.DeserializeWithRequiredFieldValidation<object>(
            jsonContent,
            _jsonSerializerOptions
        );

        // Validate the response
        // Skip validation for primitive types or OneOf types

        return result;
    }
}
