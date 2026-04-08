namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for EditPurchaseOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class EditPurchaseOkResponseValidator : AbstractValidator<EditPurchaseOkResponse>
{
    public EditPurchaseOkResponseValidator()
    {
        RuleFor(EditPurchaseOkResponse => EditPurchaseOkResponse.PurchaseId)
            .NotNull()
            .WithMessage("Field purchaseId is required and cannot be null.");
    }
}
