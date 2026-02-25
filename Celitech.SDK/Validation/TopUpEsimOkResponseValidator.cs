namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for TopUpEsimOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class TopUpEsimOkResponseValidator : AbstractValidator<TopUpEsimOkResponse>
{
    public TopUpEsimOkResponseValidator()
    {
        RuleFor(TopUpEsimOkResponse => TopUpEsimOkResponse.Purchase)
            .Custom(
                (topUpEsimOkResponsePurchase, context) =>
                {
                    if (topUpEsimOkResponsePurchase != null)
                    {
                        var validator = new TopUpEsimOkResponsePurchaseValidator();
                        var result = validator.Validate(topUpEsimOkResponsePurchase);
                        if (!result.IsValid)
                        {
                            foreach (var failure in result.Errors)
                            {
                                context.AddFailure(failure.PropertyName, failure.ErrorMessage);
                            }
                        }
                    }
                }
            )
            .NotNull()
            .WithMessage("Field purchase is required and cannot be null.");
        RuleFor(TopUpEsimOkResponse => TopUpEsimOkResponse.Profile)
            .Custom(
                (topUpEsimOkResponseProfile, context) =>
                {
                    if (topUpEsimOkResponseProfile != null)
                    {
                        var validator = new TopUpEsimOkResponseProfileValidator();
                        var result = validator.Validate(topUpEsimOkResponseProfile);
                        if (!result.IsValid)
                        {
                            foreach (var failure in result.Errors)
                            {
                                context.AddFailure(failure.PropertyName, failure.ErrorMessage);
                            }
                        }
                    }
                }
            )
            .NotNull()
            .WithMessage("Field profile is required and cannot be null.");
    }
}
