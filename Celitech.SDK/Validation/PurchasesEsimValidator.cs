namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for PurchasesEsim model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class PurchasesEsimValidator : AbstractValidator<PurchasesEsim>
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
