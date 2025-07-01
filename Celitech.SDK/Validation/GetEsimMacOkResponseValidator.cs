namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimMacOkResponseValidator : AbstractValidator<GetEsimMacOkResponse?>
{
    public GetEsimMacOkResponseValidator()
    {
        RuleFor(GetEsimMacOkResponse => GetEsimMacOkResponse.Esim)
            .Custom(
                (getEsimMacOkResponseEsim, context) =>
                {
                    if (getEsimMacOkResponseEsim != null)
                    {
                        var validator = new GetEsimMacOkResponseEsimValidator();
                        var result = validator.Validate(getEsimMacOkResponseEsim);
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
