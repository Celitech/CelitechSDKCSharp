namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for CreatePurchaseV2Request model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseV2RequestValidator : AbstractValidator<CreatePurchaseV2Request>
{
    public CreatePurchaseV2RequestValidator()
    {
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Destination)
            .NotNull()
            .WithMessage("Field destination is required and cannot be null.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required and cannot be null.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Quantity)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Minimum for quantity is 1.")
            .LessThanOrEqualTo(5)
            .WithMessage("Minimum for quantity is 5.")
            .NotNull()
            .WithMessage("Field quantity is required and cannot be null.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.StartDate)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field StartDate cannot be null when provided.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.EndDate)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field EndDate cannot be null when provided.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Duration)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field Duration cannot be null when provided.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.Email)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field Email cannot be null when provided.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.ReferenceId)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field ReferenceId cannot be null when provided.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.NetworkBrand)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field NetworkBrand cannot be null when provided.");
        RuleFor(CreatePurchaseV2Request => CreatePurchaseV2Request.EmailBrand)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field EmailBrand cannot be null when provided.");
    }
}
