namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for EditPurchaseRequest model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class EditPurchaseRequestValidator : AbstractValidator<EditPurchaseRequest>
{
    public EditPurchaseRequestValidator()
    {
        RuleFor(EditPurchaseRequest => EditPurchaseRequest.PurchaseId)
            .NotNull()
            .WithMessage("Field purchaseId is required and cannot be null.");
        RuleFor(EditPurchaseRequest => EditPurchaseRequest.StartDate)
            .NotNull()
            .WithMessage("Field startDate is required and cannot be null.");
        RuleFor(EditPurchaseRequest => EditPurchaseRequest.EndDate)
            .NotNull()
            .WithMessage("Field endDate is required and cannot be null.");
    }
}
