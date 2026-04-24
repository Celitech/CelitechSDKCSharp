namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for History model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class HistoryValidator : AbstractValidator<History>
{
    public HistoryValidator()
    {
        RuleFor(History => History.Status)
            .NotNull()
            .WithMessage("Field status is required and cannot be null.");
        RuleFor(History => History.StatusDate)
            .NotNull()
            .WithMessage("Field statusDate is required and cannot be null.");
        RuleFor(History => History.Date)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field Date cannot be null when provided.");
    }
}
