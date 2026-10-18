namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.GetEsimHistoryOkResponseEsim model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetEsimHistoryOkResponseEsimValidator
    : AbstractValidator<global::Celitech.SDK.Models.GetEsimHistoryOkResponseEsim>
{
    public GetEsimHistoryOkResponseEsimValidator()
    {
        RuleFor(GetEsimHistoryOkResponseEsim => GetEsimHistoryOkResponseEsim.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Maximum length for iccid is 22.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
        RuleFor(GetEsimHistoryOkResponseEsim => GetEsimHistoryOkResponseEsim.History)
            .Custom(
                (history, context) =>
                {
                    if (history != null)
                    {
                        var itemValidator = new HistoryValidator();
                        var index = 0;
                        foreach (var item in history)
                        {
                            if (item != null)
                            {
                                var result = itemValidator.Validate(item);
                                if (!result.IsValid)
                                {
                                    foreach (var failure in result.Errors)
                                    {
                                        var propertyPath = string.IsNullOrEmpty(
                                            failure.PropertyName
                                        )
                                            ? $"History[{index}]"
                                            : $"History[{index}].{failure.PropertyName}";
                                        context.AddFailure(propertyPath, failure.ErrorMessage);
                                    }
                                }
                            }
                            index++;
                        }
                    }
                }
            )
            .NotNull()
            .WithMessage("Field history is required and cannot be null.");
    }
}
