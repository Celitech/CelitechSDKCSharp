namespace Celitech.SDK.Validation;

using Celitech.SDK.Models;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// FluentValidation validator for CreatePurchaseV2RequestLanguage model.
/// Defines validation rules for required fields, formats, ranges, and constraints based on the API schema.
/// Automatically validates instances during request serialization and response deserialization.
/// </summary>
public class CreatePurchaseV2RequestLanguageValidator
    : AbstractValidator<CreatePurchaseV2RequestLanguage>
{
    public CreatePurchaseV2RequestLanguageValidator() { }
}
