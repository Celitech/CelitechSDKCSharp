namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetPurchaseConsumptionOkResponseValidator
    : AbstractValidator<GetPurchaseConsumptionOkResponse?>
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
