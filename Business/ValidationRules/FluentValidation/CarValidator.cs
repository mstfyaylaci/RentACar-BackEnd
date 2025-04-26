using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.BrandId).GreaterThan(0);

            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ColorId).GreaterThan(0);

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).NotNull();

            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).NotNull();
            RuleFor(c => c.CarName).MinimumLength(1);
            RuleFor(c => c.CarName).MaximumLength(50);

            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).NotNull();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).MaximumLength(50);


        }

        
    }
}
