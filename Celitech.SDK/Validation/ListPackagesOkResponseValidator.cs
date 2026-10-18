namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.ListPackagesOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class ListPackagesOkResponseValidator
    : AbstractValidator<global::Celitech.SDK.Models.ListPackagesOkResponse>
{
    public ListPackagesOkResponseValidator()
    {
        RuleFor(ListPackagesOkResponse => ListPackagesOkResponse.Packages)
            .Custom(
                (packages, context) =>
                {
                    if (packages != null)
                    {
                        var itemValidator = new PackagesValidator();
                        var index = 0;
                        foreach (var item in packages)
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
                                            ? $"Packages[{index}]"
                                            : $"Packages[{index}].{failure.PropertyName}";
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
            .WithMessage("Field packages is required and cannot be null.");
    }
}
