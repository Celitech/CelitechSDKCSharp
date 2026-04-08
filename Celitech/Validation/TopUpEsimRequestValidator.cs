namespace Celitech.Validation;

using Celitech.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for TopUpEsimRequest model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class TopUpEsimRequestValidator : AbstractValidator<TopUpEsimRequest>
{
    public TopUpEsimRequestValidator()
    {
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.Iccid)
            .MinimumLength(18)
            .WithMessage("Minimum length for iccid is 18.")
            .MaximumLength(22)
            .WithMessage("Minimum length for iccid is 18.")
            .NotNull()
            .WithMessage("Field iccid is required and cannot be null.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.DataLimitInGb)
            .NotNull()
            .WithMessage("Field dataLimitInGB is required and cannot be null.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.StartDate)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field StartDate cannot be null when provided.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.EndDate)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field EndDate cannot be null when provided.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.Duration)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field Duration cannot be null when provided.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.Email)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field Email cannot be null when provided.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.ReferenceId)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field ReferenceId cannot be null when provided.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.EmailBrand)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field EmailBrand cannot be null when provided.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.StartTime)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field StartTime cannot be null when provided.");
        RuleFor(TopUpEsimRequest => TopUpEsimRequest.EndTime)
            .Must(opt => !opt.IsProvided || opt.Value != null)
            .WithMessage("Field EndTime cannot be null when provided.");
    }
}
