using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.Entityframework
{
    public class EfCustomerCreditCard:EfEntityrepository<CustomerCreditCard, RentACarContext>, ICustomerCreditCardDal
    {
    }
}
