using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfCustomerDal : EfEntityrepository<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CompanyName = cu.CompanyName,
                             };
                return result.ToList();
            }
        }
    }
}
