using Core.Utilities.Result;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        // ValidationTool.Validate(new CarValidator(),car);=>>> yapısında yazabilmemizi sağlayan generic yapı.
        // daha sonra bunu AOP şekilde yazılacak
        public static void Validate(IValidator validator, object entity) // Ivalidator üzeinden validator clasına erişiyoruz
        {
            var context = new ValidationContext<object>(entity); // sana bir obje verilecek onunşa işlem yap


            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
