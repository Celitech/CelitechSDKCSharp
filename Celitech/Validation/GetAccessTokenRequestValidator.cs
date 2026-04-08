namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for GetAccessTokenRequest model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetAccessTokenRequestValidator : AbstractValidator<GetAccessTokenRequest>
{
    public GetAccessTokenRequestValidator()
    {
        RuleFor(GetAccessTokenRequest => GetAccessTokenRequest.GrantType)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field GrantType cannot be null when provided.");
        RuleFor(GetAccessTokenRequest => GetAccessTokenRequest.ClientId)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field ClientId cannot be null when provided.");
        RuleFor(GetAccessTokenRequest => GetAccessTokenRequest.ClientSecret)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field ClientSecret cannot be null when provided.");
    }
}
