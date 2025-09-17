namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseRequestValidator : AbstractValidator<CreatePurchaseRequest?>
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
