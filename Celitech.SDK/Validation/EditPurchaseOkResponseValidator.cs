namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.EditPurchaseOkResponse model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class EditPurchaseOkResponseValidator
    : AbstractValidator<global::Celitech.SDK.Models.EditPurchaseOkResponse>
{
    public EditPurchaseOkResponseValidator()
    {
        RuleFor(EditPurchaseOkResponse => EditPurchaseOkResponse.PurchaseId)
            .NotNull()
            .WithMessage("Field purchaseId is required and cannot be null.");
    }
}
