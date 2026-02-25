namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for CreatePurchaseRequest model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseRequestValidator : AbstractValidator<CreatePurchaseRequest>
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
    }
}
