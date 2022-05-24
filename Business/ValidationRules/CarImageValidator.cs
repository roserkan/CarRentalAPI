﻿using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules;

public class CarImageValidator : AbstractValidator<CarImage>
{
    public CarImageValidator()
    {
        RuleFor(I => I.CarId).NotEmpty();
    }
}

