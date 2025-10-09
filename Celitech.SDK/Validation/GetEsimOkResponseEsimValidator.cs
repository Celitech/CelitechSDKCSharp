namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimOkResponseEsimValidator : AbstractValidator<GetEsimOkResponseEsim?>
{
    public GetEsimOkResponseEsimValidator()
    {
        RuleFor(GetEsimOkResponseEsim => GetEsimOkResponseEsim.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
        RuleFor(GetEsimOkResponseEsim => GetEsimOkResponseEsim.SmdpAddress)
            .NotNull()
            .WithMessage("Field smdpAddress is required and cannot be null.");
        RuleFor(GetEsimOkResponseEsim => GetEsimOkResponseEsim.ActivationCode)
            .MinimumLength(1000)
            .WithMessage("Minimum length for activationCode is 1000.")
            .MaximumLength(8000)
            .WithMessage("Minimum length for activationCode is 1000.")
            .NotNull()
            .WithMessage("Field activationCode is required and cannot be null.");
        RuleFor(GetEsimOkResponseEsim => GetEsimOkResponseEsim.ManualActivationCode)
            .NotNull()
            .WithMessage("Field manualActivationCode is required and cannot be null.");
        RuleFor(GetEsimOkResponseEsim => GetEsimOkResponseEsim.Status)
            .NotNull()
            .WithMessage("Field status is required and cannot be null.");
        RuleFor(GetEsimOkResponseEsim => GetEsimOkResponseEsim.IsTopUpAllowed)
            .NotNull()
            .WithMessage("Field isTopUpAllowed is required and cannot be null.");
    }
}
