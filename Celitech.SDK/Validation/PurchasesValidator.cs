namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class PurchasesValidator : AbstractValidator<Purchases?>
{
    public PurchasesValidator()
    {
        RuleFor(Purchases => Purchases.Id)
            .NotNull()
            .WithMessage("Field id is required and cannot be null.");
        RuleFor(Purchases => Purchases.StartDate)
            .NotNull()
            .WithMessage("Field startDate is required and cannot be null.");
        RuleFor(Purchases => Purchases.EndDate)
            .NotNull()
            .WithMessage("Field endDate is required and cannot be null.");
        RuleFor(Purchases => Purchases.CreatedDate)
            .NotNull()
            .WithMessage("Field createdDate is required and cannot be null.");
        RuleFor(Purchases => Purchases.Package1)
            .Custom(
                (package, context) =>
                {
                    if (package != null)
                    {
                        var validator = new PackageValidator();
                        var result = validator.Validate(package);
                        if (!result.IsValid)
                        {
                            foreach (var failure in result.Errors)
                            {
                                context.AddFailure(failure.PropertyName, failure.ErrorMessage);
                            }
                        }
                    }
                }
            )
            .NotNull()
            .WithMessage("Field package is required and cannot be null.");
        RuleFor(Purchases => Purchases.Esim)
            .Custom(
                (purchasesEsim, context) =>
                {
                    if (purchasesEsim != null)
                    {
                        var validator = new PurchasesEsimValidator();
                        var result = validator.Validate(purchasesEsim);
                        if (!result.IsValid)
                        {
                            foreach (var failure in result.Errors)
                            {
                                context.AddFailure(failure.PropertyName, failure.ErrorMessage);
                            }
                        }
                    }
                }
            )
            .NotNull()
            .WithMessage("Field esim is required and cannot be null.");
        RuleFor(Purchases => Purchases.Source)
            .NotNull()
            .WithMessage("Field source is required and cannot be null.");
        RuleFor(Purchases => Purchases.PurchaseType)
            .NotNull()
            .WithMessage("Field purchaseType is required and cannot be null.");
    }
}
