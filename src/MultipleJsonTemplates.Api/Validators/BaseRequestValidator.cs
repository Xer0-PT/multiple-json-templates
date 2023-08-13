using FluentValidation;
using MultipleJsonTemplates.Api.Contracts;

namespace MultipleJsonTemplates.Api.Validators;

public class BaseRequestValidator : AbstractValidator<BaseRequest>
{
    public BaseRequestValidator()
    {
        RuleFor(x => x.TemplateName)
            .Must(x => TemplateNames.ValidTemplateNames.Contains(x))
            .WithMessage("Unknown template.");
    }
}