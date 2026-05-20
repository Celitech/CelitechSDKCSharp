namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.OAuthTokenRequest model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class OAuthTokenRequestValidator
    : AbstractValidator<global::Celitech.SDK.Models.OAuthTokenRequest>
{
    public OAuthTokenRequestValidator()
    {
        RuleFor(OAuthTokenRequest => OAuthTokenRequest.GrantType)
            .NotNull()
            .WithMessage("Field grant_type is required and cannot be null.");
        RuleFor(OAuthTokenRequest => OAuthTokenRequest.ClientId)
            .NotNull()
            .WithMessage("Field client_id is required and cannot be null.");
        RuleFor(OAuthTokenRequest => OAuthTokenRequest.ClientSecret)
            .NotNull()
            .WithMessage("Field client_secret is required and cannot be null.");
        RuleFor(OAuthTokenRequest => OAuthTokenRequest.Scope)
            .NotNull()
            .WithMessage("Field scope is required and cannot be null.");
    }
}
