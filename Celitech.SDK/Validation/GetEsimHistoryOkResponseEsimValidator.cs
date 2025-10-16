namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimHistoryOkResponseEsimValidator
    : AbstractValidator<GetEsimHistoryOkResponseEsim?>
{
    public GetEsimHistoryOkResponseEsimValidator()
    {
        RuleFor(GetEsimHistoryOkResponseEsim => GetEsimHistoryOkResponseEsim.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
        RuleFor(GetEsimHistoryOkResponseEsim => GetEsimHistoryOkResponseEsim.History1)
            .NotNull()
            .WithMessage("Field history is required and cannot be null.");
    }
}
