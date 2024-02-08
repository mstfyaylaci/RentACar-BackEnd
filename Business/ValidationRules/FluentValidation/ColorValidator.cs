using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).MinimumLength(2);
            RuleFor(c => c.ColorName).Must(IsNumber).WithMessage(Message.IsColorNameNumber);
        }

        private bool IsNumber(string arg)
        {
            return !arg.Any(char.IsDigit);
        }
    }
}
