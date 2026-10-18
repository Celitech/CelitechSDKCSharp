namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.ListPurchasesOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class ListPurchasesOkResponseValidator
    : AbstractValidator<global::Celitech.SDK.Models.ListPurchasesOkResponse>
{
    public ListPurchasesOkResponseValidator()
    {
        RuleFor(ListPurchasesOkResponse => ListPurchasesOkResponse.Purchases)
            .Custom(
                (purchases, context) =>
                {
                    if (purchases != null)
                    {
                        var itemValidator = new PurchasesValidator();
                        var index = 0;
                        foreach (var item in purchases)
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
                                            ? $"Purchases[{index}]"
                                            : $"Purchases[{index}].{failure.PropertyName}";
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
            .WithMessage("Field purchases is required and cannot be null.");
    }
}
