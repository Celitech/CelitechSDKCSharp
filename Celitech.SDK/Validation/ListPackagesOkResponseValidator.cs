namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class ListPackagesOkResponseValidator : AbstractValidator<ListPackagesOkResponse?>
{
    public ListPackagesOkResponseValidator()
    {
        RuleFor(ListPackagesOkResponse => ListPackagesOkResponse.Packages1)
            .NotNull()
            .WithMessage("Field packages is required and cannot be null.");
    }
}
