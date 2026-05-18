namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.TopUpEsimOkResponseProfile model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class TopUpEsimOkResponseProfileValidator
    : AbstractValidator<global::Celitech.SDK.Models.TopUpEsimOkResponseProfile>
{
    public TopUpEsimOkResponseProfileValidator()
    {
        RuleFor(TopUpEsimOkResponseProfile => TopUpEsimOkResponseProfile.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
    }
}
