namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class CreatePurchaseV2OkResponseValidator : AbstractValidator<CreatePurchaseV2OkResponse?>
{
    public CreatePurchaseV2OkResponseValidator()
    {
        RuleFor(CreatePurchaseV2OkResponse => CreatePurchaseV2OkResponse.Profile)
            .Custom(
                (createPurchaseV2OkResponseProfile, context) =>
                {
                    if (createPurchaseV2OkResponseProfile != null)
                    {
                        var validator = new CreatePurchaseV2OkResponseProfileValidator();
                        var result = validator.Validate(createPurchaseV2OkResponseProfile);
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
