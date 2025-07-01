namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class GetEsimOkResponseValidator : AbstractValidator<GetEsimOkResponse?>
{
    public GetEsimOkResponseValidator()
    {
        RuleFor(GetEsimOkResponse => GetEsimOkResponse.Esim)
            .Custom(
                (getEsimOkResponseEsim, context) =>
                {
                    if (getEsimOkResponseEsim != null)
                    {
                        var validator = new GetEsimOkResponseEsimValidator();
                        var result = validator.Validate(getEsimOkResponseEsim);
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
