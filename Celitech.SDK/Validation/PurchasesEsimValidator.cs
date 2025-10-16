namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class PurchasesEsimValidator : AbstractValidator<PurchasesEsim?>
{
    public PurchasesEsimValidator()
    {
        RuleFor(PurchasesEsim => PurchasesEsim.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
    }
}
