using System.Net.Http.Json;
using Celitech.Config;
using Celitech.Http;
using Celitech.Http.Exceptions;
using Celitech.Http.Extensions;
using Celitech.Http.Handlers;
using Celitech.Http.Serialization;
using Celitech.Models;
using Celitech.Validation;
using Celitech.Validation.Extensions;

namespace Celitech.Services;

/// <summary>
/// Service class providing access to API endpoints for ESimService.
/// Inherits HTTP client management, JSON serialization, and streaming capabilities from the base service.
/// Each method corresponds to an API operation and handles request building, execution, and response parsing.
/// </summary>
public class ESimService : BaseService
{
    private RequestConfig? _getEsimAsyncConfig;
    private RequestConfig? _getEsimDeviceAsyncConfig;
    private RequestConfig? _getEsimHistoryAsyncConfig;

    internal ESimService(Client httpClient)
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

    /// <summary>Get eSIM</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async Task<GetEsimOkResponse> GetEsimAsync(
        string iccid,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(iccid, nameof(iccid));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateRequired<string>(iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_getEsimAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "esim")
            .SetQueryParameter("iccid", iccid)
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
            DeserializationValidation.DeserializeWithRequiredFieldValidation<GetEsimOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new GetEsimOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }

    /// <summary>Get eSIM Device</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async Task<GetEsimDeviceOkResponse> GetEsimDeviceAsync(
        string iccid,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(iccid, nameof(iccid));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateRequired<string>(iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_getEsimDeviceAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "esim/{iccid}/device")
            .SetPathParameter("iccid", iccid)
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
            DeserializationValidation.DeserializeWithRequiredFieldValidation<GetEsimDeviceOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new GetEsimDeviceOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }

    /// <summary>Get eSIM History</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async Task<GetEsimHistoryOkResponse> GetEsimHistoryAsync(
        string iccid,
        RequestConfig? requestConfig = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(iccid, nameof(iccid));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateRequired<string>(iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var resolvedConfig = GetResolvedConfig(_getEsimHistoryAsyncConfig, requestConfig);

        var request = new RequestBuilder(HttpMethod.Get, "esim/{iccid}/history")
            .SetPathParameter("iccid", iccid)
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
            DeserializationValidation.DeserializeWithRequiredFieldValidation<GetEsimHistoryOkResponse>(
                jsonContent,
                _jsonSerializerOptions
            );

        // Validate the response
        var responseValidator = new GetEsimHistoryOkResponseValidator();
        var responseValidationResult = responseValidator.ValidateRequired(result);
        if (!responseValidationResult.IsValid)
        {
            throw new Http.Exceptions.ValidationException(responseValidationResult.Errors);
        }

        return result;
    }
}
