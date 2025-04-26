using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        private ICreditCardService _creditCardService;

        public PaymentManager(IPaymentDal paymentDal, ICreditCardService creditCardService)
        {
            _paymentDal = paymentDal;
            _creditCardService = creditCardService;
        }

        [TransactionScopeAspect]
        public IDataResult<int> Pay(CreditCard creditCard, int customerId, decimal amount)
        {
            var result = _creditCardService.Validate(creditCard);

            if (result.Success)
            {
                if (creditCard.Balance<amount)
                {
                    return new ErrorDataResult<int>(-1, Messages.InsufficientCardBalance);
                }

                creditCard.Balance -= amount;
                _creditCardService.Update(creditCard);
                var payment = new Payment
                {
                    CustomerId = customerId,
                    CreditCardId = creditCard.Id,
                    Amount = amount,
                    PaymentDate = DateTime.Now
                };

                _paymentDal.Add(payment);

                // Ödeme kaydedildikten sonra ID doğrudan alınır
                return new SuccessDataResult<int>(payment.Id, Messages.PaymentSuccessful);
            }
            return new ErrorDataResult<int>(-1, result.Message);
        }
    }
}
