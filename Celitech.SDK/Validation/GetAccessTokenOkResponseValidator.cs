namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for GetAccessTokenOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetAccessTokenOkResponseValidator : AbstractValidator<GetAccessTokenOkResponse>
{
    public GetAccessTokenOkResponseValidator()
    {
        RuleFor(GetAccessTokenOkResponse => GetAccessTokenOkResponse.AccessToken)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field AccessToken cannot be null when provided.");
        RuleFor(GetAccessTokenOkResponse => GetAccessTokenOkResponse.TokenType)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field TokenType cannot be null when provided.");
        RuleFor(GetAccessTokenOkResponse => GetAccessTokenOkResponse.ExpiresIn)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field ExpiresIn cannot be null when provided.");
    }
}
