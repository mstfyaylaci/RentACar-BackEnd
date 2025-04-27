using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<Customer> GetById(int id);
        IDataResult<Customer> GetCustomerByUserId(int userId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
