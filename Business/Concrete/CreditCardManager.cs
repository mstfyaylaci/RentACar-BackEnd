using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validaton;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;


namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        

        IDataResult<CreditCard> ICreditCardService.GetById(int creditCardId)
        {
            var creditCard = _creditCardDal.Get(c => c.Id == creditCardId); ;

            if (creditCard != null)
            {
                return new SuccessDataResult<CreditCard>(creditCard, Messages.CreditCardListed);
            }

            return new ErrorDataResult<CreditCard>(null, Messages.CreditCardNotFound);
        }

        public IDataResult<CreditCard> GetByCardInfo(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            var creditCard = GetCreditCardByCardInfo(cardNumber, expireYear, expireMonth, cvc, cardHolderFullName);

            if (creditCard == null)
            {
                return new ErrorDataResult<CreditCard>(null, Messages.CreditCardNotFound);
            }
            return new SuccessDataResult<CreditCard>(creditCard, Messages.CreditCardListed);
        }

        //public IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId)
        //{
        //    var customerCreditCards = _creditCardDal.GetAll(c => c.CustomerId == customerId);
        //    if (customerCreditCards == null || !customerCreditCards.Any())
        //    {
        //        return new ErrorDataResult<List<CreditCard>>(null, Messages.CreditCardNotFound);
        //    }
        //    return new SuccessDataResult<List<CreditCard>>(customerCreditCards, Messages.CreditCardListed);
        //}


        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Validate(CreditCard creditCard)
        {
            var creditCardToValidate = GetCreditCardByCardInfo(creditCard.CardNumber, creditCard.ExpireYear, creditCard.ExpireMonth, creditCard.Cvc, creditCard.CardHolderFullName);
            if (creditCardToValidate == null)
            {
                return new ErrorResult(Messages.CreditCardNotValid);
            }
            return new SuccessResult();
        }

        
        
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded); // Success mesajı
        }

       

        public IResult Delete(int creditCardId)
        {
            var creditCard = _creditCardDal.Get(c => c.Id == creditCardId);
            if (creditCard == null)
            {
                return new ErrorResult(Messages.CreditCardNotFound);
            }

            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        private CreditCard GetCreditCardByCardInfo(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            return _creditCardDal.GetAll(c =>
            c.CardNumber == cardNumber &&
            c.ExpireYear == expireYear &&
            c.ExpireMonth == expireMonth &&
            c.Cvc == cvc)
                .FirstOrDefault(c => c.CardHolderFullName.ToUpperInvariant() == cardHolderFullName.ToUpperInvariant());
        }
    }
}
