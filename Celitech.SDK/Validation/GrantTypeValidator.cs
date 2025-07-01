namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GrantTypeValidator : AbstractValidator<GrantType?>
{
    public GrantTypeValidator() { }
}
