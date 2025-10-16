namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

public class ListDestinationsOkResponseValidator : AbstractValidator<ListDestinationsOkResponse?>
{
    public ListDestinationsOkResponseValidator()
    {
        RuleFor(ListDestinationsOkResponse => ListDestinationsOkResponse.Destinations1)
            .NotNull()
            .WithMessage("Field destinations is required and cannot be null.");
    }
}
