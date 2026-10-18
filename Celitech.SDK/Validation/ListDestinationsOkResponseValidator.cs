namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.ListDestinationsOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class ListDestinationsOkResponseValidator
    : AbstractValidator<global::Celitech.SDK.Models.ListDestinationsOkResponse>
{
    public ListDestinationsOkResponseValidator()
    {
        RuleFor(ListDestinationsOkResponse => ListDestinationsOkResponse.Destinations)
            .Custom(
                (destinations, context) =>
                {
                    if (destinations != null)
                    {
                        var itemValidator = new DestinationsValidator();
                        var index = 0;
                        foreach (var item in destinations)
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
                                            ? $"Destinations[{index}]"
                                            : $"Destinations[{index}].{failure.PropertyName}";
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
            .WithMessage("Field destinations is required and cannot be null.");
    }
}
