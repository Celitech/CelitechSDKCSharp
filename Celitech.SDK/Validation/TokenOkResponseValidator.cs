namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class TokenOkResponseValidator : AbstractValidator<TokenOkResponse?>
{
    public TokenOkResponseValidator()
    {
        RuleFor(TokenOkResponse => TokenOkResponse.Token)
            .NotNull()
            .WithMessage("Field token is required and cannot be null.");
    }
}
