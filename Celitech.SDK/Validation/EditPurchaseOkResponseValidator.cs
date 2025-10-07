namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class EditPurchaseOkResponseValidator : AbstractValidator<EditPurchaseOkResponse?>
{
    public EditPurchaseOkResponseValidator()
    {
        RuleFor(EditPurchaseOkResponse => EditPurchaseOkResponse.PurchaseId)
            .NotNull()
            .WithMessage("Field purchaseId is required and cannot be null.");
        RuleFor(EditPurchaseOkResponse => EditPurchaseOkResponse.NewStartDate)
            .NotNull()
            .WithMessage("Field newStartDate is required and cannot be null.");
        RuleFor(EditPurchaseOkResponse => EditPurchaseOkResponse.NewEndDate)
            .NotNull()
            .WithMessage("Field newEndDate is required and cannot be null.");
    }
}
