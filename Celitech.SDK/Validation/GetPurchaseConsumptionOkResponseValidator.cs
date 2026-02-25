namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for GetPurchaseConsumptionOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class GetPurchaseConsumptionOkResponseValidator
    : AbstractValidator<GetPurchaseConsumptionOkResponse>
{
    public GetPurchaseConsumptionOkResponseValidator()
    {
        RuleFor(GetPurchaseConsumptionOkResponse =>
                GetPurchaseConsumptionOkResponse.DataUsageRemainingInBytes
            )
            .NotNull()
            .WithMessage("Field dataUsageRemainingInBytes is required and cannot be null.");
        RuleFor(GetPurchaseConsumptionOkResponse => GetPurchaseConsumptionOkResponse.Status)
            .NotNull()
            .WithMessage("Field status is required and cannot be null.");
    }
}
