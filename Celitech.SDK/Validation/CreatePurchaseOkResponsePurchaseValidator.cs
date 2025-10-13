namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseOkResponsePurchaseValidator
    : AbstractValidator<CreatePurchaseOkResponsePurchase?>
{
    public CreatePurchaseOkResponsePurchaseValidator()
    {
        RuleFor(CreatePurchaseOkResponsePurchase => CreatePurchaseOkResponsePurchase.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(CreatePurchaseOkResponsePurchase => CreatePurchaseOkResponsePurchase.PackageId)
            .NotNull()
            .WithMessage("Field packageId is required and cannot be null.");

        RuleFor(CreatePurchaseOkResponsePurchase => CreatePurchaseOkResponsePurchase.CreatedDate)
            .NotNull()
            .WithMessage("Field createdDate is required and cannot be null.");
    }
}
