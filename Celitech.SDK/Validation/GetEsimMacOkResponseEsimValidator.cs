namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimMacOkResponseEsimValidator : AbstractValidator<GetEsimMacOkResponseEsim?>
{
    public GetEsimMacOkResponseEsimValidator()
    {
        RuleFor(GetEsimMacOkResponseEsim => GetEsimMacOkResponseEsim.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.");
    }
}
