using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Models;

namespace Business.Abstract
{
    public interface ICustomerCreditCardService
    {
        IDataResult<List<CreditCard>> GetSavedCreditCardsByCustomerId(int customerId);

        IResult SaveCustomerCreditCard(CustomerCreditCardModel customerCreditCardModel);
        IResult DeleteCustomerCreditCard(CustomerCreditCardModel customerCreditCardModel);
    }
}
