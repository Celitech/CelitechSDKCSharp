namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for global::Celitech.SDK.Models.CreatePurchaseRequest model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseRequestValidator
    : AbstractValidator<global::Celitech.SDK.Models.CreatePurchaseRequest>
{
    public CreatePurchaseRequestValidator()
    {
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.Destination)
            .NotNull()
            .WithMessage("Field destination is required and cannot be null.");
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required and cannot be null.");
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.StartDate)
            .NotNull()
            .WithMessage("Field startDate is required and cannot be null.");
        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.EndDate)
            .NotNull()
            .WithMessage("Field endDate is required and cannot be null.");

        RuleFor(CreatePurchaseRequest => CreatePurchaseRequest.ReferenceId)
            .MaximumLength(255)
            .WithMessage("Maximum length for referenceId is 255.")
            .Matches(@"^[a-zA-Z0-9\-_.@+]+$")
            .WithMessage(@"Pattern for referenceId must match ^[a-zA-Z0-9\-_.@+]+$.");
    }
}
