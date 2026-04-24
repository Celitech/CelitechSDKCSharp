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
/// Service class providing access to API endpoints for IFrameService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class IFrameService : BaseService
{
    private RequestConfig? _tokenAsyncConfig;

    internal IFrameService(Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>TokenAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public IFrameService SetTokenAsyncConfig(RequestConfig config)
    {
        _tokenAsyncConfig = config;
        return this;
    }

    /// <summary>Generate a new token to be used in the iFrame</summary>
    public async Task<TokenOkResponse> TokenAsync(
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_tokenAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Post, "iframe/token")
            .SetScopes(new HashSet<string> { })
            .AddError(400, "application/json", typeof(BadRequest), typeof(BadRequestException))
            .AddError(401, "application/json", typeof(Unauthorized), typeof(UnauthorizedException))
            .Build();

        var response = await ExecuteAsync(request, resolvedConfig, cancellationToken)
            .ConfigureAwait(false);

        // Custom deserialization with required field validation for JSON responses
        var jsonContent = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var result =
            DeserializationValidation.DeserializeWithRequiredFieldValidation<TokenOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new TokenOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }
}
