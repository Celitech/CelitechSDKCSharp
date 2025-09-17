namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class TopUpEsimRequestValidator : AbstractValidator<TopUpEsimRequest?>
{
    public TopUpEsimRequestValidator()
    {
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required and cannot be null.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.StartDate)
            .NotNull()
            .WithMessage("Field startDate is required and cannot be null.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.EndDate)
            .NotNull()
            .WithMessage("Field endDate is required and cannot be null.");
    }
}
