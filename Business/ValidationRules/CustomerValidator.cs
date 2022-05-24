using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.CustomerName).NotEmpty();
        RuleFor(c => c.CustomerName).MinimumLength(3);
        RuleFor(c => c.UserId).NotEmpty();
    }
}

