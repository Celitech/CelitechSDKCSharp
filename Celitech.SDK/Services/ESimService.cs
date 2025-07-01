using System.Net.Http.Json;
using Celitech.SDK.Http;
using Celitech.SDK.Http.Exceptions;
using Celitech.SDK.Http.Extensions;
using Celitech.SDK.Http.Serialization;
using Celitech.SDK.Models;
using Celitech.SDK.Validation;
using Celitech.SDK.Validation.Extensions;

namespace Celitech.SDK.Services;

public class ESimService : BaseService
{
    internal ESimService(HttpClient httpClient)
        : base(httpClient) { }

    /// <summary>Get eSIM Status</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async Task<GetEsimOkResponse> GetEsimAsync(
        string iccid,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(iccid, nameof(iccid));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateRequired<string?>((string?)iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "esim")
            .SetQueryParameter("iccid", iccid)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetEsimOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Get eSIM Device</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async Task<GetEsimDeviceOkResponse> GetEsimDeviceAsync(
        string iccid,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(iccid, nameof(iccid));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateRequired<string?>((string?)iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "esim/{iccid}/device")
            .SetPathParameter("iccid", iccid)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetEsimDeviceOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Get eSIM History</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async Task<GetEsimHistoryOkResponse> GetEsimHistoryAsync(
        string iccid,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(iccid, nameof(iccid));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateRequired<string?>((string?)iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "esim/{iccid}/history")
            .SetPathParameter("iccid", iccid)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetEsimHistoryOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }

    /// <summary>Get eSIM MAC</summary>
    /// <param name="iccid">ID of the eSIM</param>
    public async Task<GetEsimMacOkResponse> GetEsimMacAsync(
        string iccid,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(iccid, nameof(iccid));
        var validationResults = new List<FluentValidation.Results.ValidationResult> { };
        var iccidValidationResult = new StringValidator()
            .WithMaximumLength(22)
            .WithMinimumLength(18)
            .ValidateRequired<string?>((string?)iccid);
        if (iccidValidationResult != null)
        {
            validationResults.Add(iccidValidationResult);
        }

        var combinedFailures = validationResults.SelectMany(result => result.Errors).ToList();
        if (combinedFailures.Any())
        {
            throw new Http.Exceptions.ValidationException(combinedFailures);
        }

        var request = new RequestBuilder(HttpMethod.Get, "esim/{iccid}/mac")
            .SetPathParameter("iccid", iccid)
            .SetScopes(new HashSet<string> { })
            .Build();

        var response = await _httpClient
            .SendAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return await response
                .EnsureSuccessfulResponse()
                .Content.ReadFromJsonAsync<GetEsimMacOkResponse>(
                    _jsonSerializerOptions,
                    cancellationToken
                )
                .ConfigureAwait(false) ?? throw new Exception("Failed to deserialize response.");
    }
}
