namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class EditPurchaseRequestValidator : AbstractValidator<EditPurchaseRequest?>
{
    public EditPurchaseRequestValidator()
    {
        RuleFor(EditPurchaseRequest => EditPurchaseRequest.PurchaseId)
            .NotNull()
            .WithMessage("Field purchaseId is required.");
        RuleFor(EditPurchaseRequest => EditPurchaseRequest.StartDate)
            .NotNull()
            .WithMessage("Field startDate is required.");
        RuleFor(EditPurchaseRequest => EditPurchaseRequest.EndDate)
            .NotNull()
            .WithMessage("Field endDate is required.");
    }
}
