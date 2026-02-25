namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for CreatePurchaseOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseOkResponseValidator : AbstractValidator<CreatePurchaseOkResponse>
{
    public CreatePurchaseOkResponseValidator()
    {
        RuleFor(CreatePurchaseOkResponse => CreatePurchaseOkResponse.Purchase)
            .Custom(
                (createPurchaseOkResponsePurchase, context) =>
                {
                    if (createPurchaseOkResponsePurchase != null)
                    {
                        var validator = new CreatePurchaseOkResponsePurchaseValidator();
                        var result = validator.Validate(createPurchaseOkResponsePurchase);
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
        RuleFor(CreatePurchaseOkResponse => CreatePurchaseOkResponse.Profile)
            .Custom(
                (createPurchaseOkResponseProfile, context) =>
                {
                    if (createPurchaseOkResponseProfile != null)
                    {
                        var validator = new CreatePurchaseOkResponseProfileValidator();
                        var result = validator.Validate(createPurchaseOkResponseProfile);
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
