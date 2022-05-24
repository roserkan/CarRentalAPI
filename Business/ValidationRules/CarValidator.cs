using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules;

public class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.ColorId).NotEmpty();
        RuleFor(c => c.DailyPrice).NotEmpty();
        RuleFor(c => c.DailyPrice).GreaterThan(0);
        RuleFor(c => c.Descriptions).NotEmpty();
        RuleFor(c => c.ModelYear).NotEmpty();
    }
}

