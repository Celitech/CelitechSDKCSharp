namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class HistoryValidator : AbstractValidator<History?>
{
    public HistoryValidator()
    {
        RuleFor(History => History.Status)
            .NotNull()
            .WithMessage("Field status is required and cannot be null.");
        RuleFor(History => History.StatusDate)
            .NotNull()
            .WithMessage("Field statusDate is required and cannot be null.");
    }
}
