using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Concrete.Entityframework
{
    public class EfCreditDal : EfEntityrepository<CreditCard, RentACarContext>, ICreditCardDal
    {
        
    }
}
