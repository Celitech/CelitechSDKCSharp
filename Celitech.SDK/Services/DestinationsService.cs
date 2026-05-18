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
/// Service class providing access to API endpoints for DestinationsService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class DestinationsService : BaseService
{
    private RequestConfig? _listDestinationsAsyncConfig;

    internal DestinationsService(Client httpClient)
        : base(httpClient) { }

    /// <summary>
    /// Sets method-level configuration for <c>ListDestinationsAsync</c>.
    /// Method-level config overrides service-level config but is overridden by per-request config.
    /// </summary>
    public DestinationsService SetListDestinationsAsyncConfig(RequestConfig config)
    {
        _listDestinationsAsyncConfig = config;
        return this;
    }

    /// <summary>List Destinations</summary>
    public async Task<ListDestinationsOkResponse> ListDestinationsAsync(
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        var resolvedConfig = GetResolvedConfig(_listDestinationsAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "destinations")
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
            DeserializationValidation.DeserializeWithRequiredFieldValidation<ListDestinationsOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new ListDestinationsOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }
}
