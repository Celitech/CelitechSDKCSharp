namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.TokenOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class TokenOkResponseValidator
    : AbstractValidator<global::Celitech.SDK.Models.TokenOkResponse>
{
    public TokenOkResponseValidator()
    {
        RuleFor(TokenOkResponse => TokenOkResponse.Token)
            .NotNull()
            .WithMessage("Field token is required and cannot be null.");
    }
}
