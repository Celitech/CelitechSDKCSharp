namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseOkResponseProfileValidator
    : AbstractValidator<CreatePurchaseOkResponseProfile?>
{
    public CreatePurchaseOkResponseProfileValidator()
    {
        RuleFor(CreatePurchaseOkResponseProfile => CreatePurchaseOkResponseProfile.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
        RuleFor(CreatePurchaseOkResponseProfile => CreatePurchaseOkResponseProfile.ActivationCode)
            .MinimumLength(1000)
            .WithMessage("Minimum length for activationCode is 1000.")
            .MaximumLength(8000)
            .WithMessage("Minimum length for activationCode is 1000.")
            .NotNull()
            .WithMessage("Field activationCode is required and cannot be null.");
        RuleFor(CreatePurchaseOkResponseProfile =>
                CreatePurchaseOkResponseProfile.ManualActivationCode
            )
            .NotNull()
            .WithMessage("Field manualActivationCode is required and cannot be null.");
    }
}
