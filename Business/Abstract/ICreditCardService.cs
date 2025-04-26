using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTO;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        
        IDataResult<CreditCard> GetById(int creditCardId);

        IDataResult<CreditCard> GetByCardInfo(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName);

        //IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId);
        IResult Update(CreditCard creditCard);

        IResult Add(CreditCard creditCard);
        IResult Validate(CreditCard creditCard);

        IResult Delete(int creditCardId);

        
    }
}
