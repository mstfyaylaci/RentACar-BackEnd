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
using Entities.DTO;
using Entities.Models;

namespace Business.Concrete
{
    public class CustomerCreditCardManager : ICustomerCreditCardService
    {
        private  ICustomerCreditCardDal _customerCreditCardDal;
        private ICreditCardService _creditCardService;
        private ICreditCardDal _creditCardDal;

        public CustomerCreditCardManager(ICustomerCreditCardDal customerCreditCardDal, ICreditCardService creditCardService, ICreditCardDal creditCardDal)
        {
            _customerCreditCardDal = customerCreditCardDal;
            _creditCardService = creditCardService;
            _creditCardDal = creditCardDal;
        }



        public IDataResult<List<CreditCard>> GetSavedCreditCardsByCustomerId(int customerId)
        {
            // 1. Verilen müşteri ID'sine ait tüm müşteri-kart ilişkileri çekilir
            var customerCards = _customerCreditCardDal.GetAll(cc => cc.CustomerId == customerId);

            // 2. Döndürülecek kredi kartları listesi oluşturulur
            var savedCards = new List<CreditCard>();

            // 3. Her bir ilişki için ilgili kredi kartı bilgisi getirilir
            foreach (var result in customerCards)
            {
                var creditCard = _creditCardService.GetById(result.CreditCardId);
                if (creditCard.Success)
                {
                    savedCards.Add(creditCard.Data);
                }
                else
                {
                    return new ErrorDataResult<List<CreditCard>>(null, creditCard.Message);
                }
            }

            // 6. Tüm kartlar başarıyla toplandıysa liste döndürülür
            return new SuccessDataResult<List<CreditCard>>(savedCards, Messages.CustomersCreditCardsListed);
        }

        [TransactionScopeAspect]
        public IResult SaveCustomerCreditCard(CustomerCreditCardModel model)
        {
            var creditCardResult = _creditCardService.GetByCardInfo(model.CreditCard.CardNumber,
                                                   model.CreditCard.ExpireYear,
                                                   model.CreditCard.ExpireMonth,
                                                   model.CreditCard.Cvc,
                                                   model.CreditCard.CardHolderFullName.ToUpperInvariant());
            if (!creditCardResult.Success)
            {
                return new ErrorResult(creditCardResult.Message);
            }

            CustomerCreditCard customerCreditCard = new CustomerCreditCard
            {
                CustomerId = model.CustomerId,
                CreditCardId = creditCardResult.Data.Id
            };

            var customerCreditCardExist = _customerCreditCardDal.GetAll(ccc =>
                ccc.CustomerId == customerCreditCard.CustomerId && ccc.CreditCardId == customerCreditCard.CreditCardId);

            if (customerCreditCardExist.Count > 0) //If the customer has already saved the credit card
            {
                return new ErrorResult(Messages.CustomerCreditCardAlreadySaved);
            }

            _customerCreditCardDal.Add(customerCreditCard);

            var result = GetCustomerCreditCard(customerCreditCard);
            if (result.Success)
            {
                return new SuccessResult(Messages.CustomerCreditCardSaved);
            }

            return new ErrorResult(Messages.CustomerCreditCardFailedToSave);

        }

        [TransactionScopeAspect]
        public IResult DeleteCustomerCreditCard(CustomerCreditCardModel model)
        {
            // 1. Kart bilgileri alınır
            var card = model.CreditCard;

            // 2. Kart sistemde kayıtlı mı kontrol edilir
            var cardResult=_creditCardService.GetByCardInfo(
                card.CardNumber,
                card.ExpireYear,
                card.ExpireMonth,
                card.Cvc,
                card.CardHolderFullName.ToUpperInvariant());

            if (!cardResult.Success)
                return new ErrorResult(cardResult.Message);

            var customerCard = new CustomerCreditCard
            {
                CustomerId = model.CustomerId,
                CreditCardId = cardResult.Data.Id
            };
            // 3. Kart müşteriyle ilişkilendirilmiş mi kontrol edilir
            var extingCustomerCard = GetCustomerCreditCard(customerCard);

            if (!extingCustomerCard.Success)
                return new ErrorResult(Messages.CustomerCreditCardNotFound);

            // 4. Kart müşteriyle ilişkilendirilmişse silinir
            _customerCreditCardDal.Delete(extingCustomerCard.Data);
            return new SuccessResult(Messages.CustomerCreditCardDeleted);

            
            // 7. Silme sonrası kontrol yapılır: ilişki sistemde yoksa başarı döndürülür
            var check = GetCustomerCreditCard(customerCard);
            return !check.Success
                ? new SuccessResult(Messages.CustomerCreditCardDeleted)
                : new ErrorResult(Messages.CustomerCreditCardNotDeleted);
        }


        private IDataResult<CustomerCreditCard> GetCustomerCreditCard(CustomerCreditCard customerCreditCard)
        {
            var result =
                _customerCreditCardDal.Get(ccc => ccc.CustomerId == customerCreditCard.CustomerId &&
                                                  ccc.CreditCardId == customerCreditCard.CreditCardId);
            if (result != null)
            {
                return new SuccessDataResult<CustomerCreditCard>(result);
            }

            return new ErrorDataResult<CustomerCreditCard>();
        }
    }
}
