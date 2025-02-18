using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validaton
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) // validatorType(örnek:carValidator) kullanarak ilgili metodu veya classı doğrula
                                                    // örnek kullanım:[ValidationAspect(typof(CarValidator))]
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) // metottan önce çalışması gereken yer
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);// reflection :çalışma anında çalış,
                                                                                 // car validatorün bir instancesini oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];  //car validatorün çalışma tipini bul.O da Car clasını denk geliyor 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // Car ın parametrelerini bul = yani paretmetresi car olan metoroları bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); // her bir metodu validete et
            }
        }
    }
}
