namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseOkResponseValidator : AbstractValidator<CreatePurchaseOkResponse?>
{
    public CreatePurchaseOkResponseValidator()
    {
        RuleFor(CreatePurchaseOkResponse => CreatePurchaseOkResponse.Profile)
            .Custom(
                (createPurchaseOkResponseProfile, context) =>
                {
                    if (createPurchaseOkResponseProfile != null)
                    {
                        var validator = new CreatePurchaseOkResponseProfileValidator();
                        var result = validator.Validate(createPurchaseOkResponseProfile);
                        if (!result.IsValid)
                        {
                            foreach (var failure in result.Errors)
                            {
                                context.AddFailure(failure.PropertyName, failure.ErrorMessage);
                            }
                        }
                    }
                }
            );
    }
}
