using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules;

public class ColorValidator : AbstractValidator<Color>
{
    public ColorValidator()
    {
        RuleFor(c => c.ColorName).NotEmpty();
        RuleFor(c => c.ColorName).MinimumLength(3);

    }
}

