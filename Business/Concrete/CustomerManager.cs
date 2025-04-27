using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Resource;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validaton;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        [SecuredOperation("admin,customer.all,customer.list")]
        [CacheAspect(10)]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        [SecuredOperation("admin,customer.all,customer.list")]
        [CacheAspect(10)]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.CustomerByListed);
        }

        //[SecuredOperation("admin,customer.all,customer.list")]
        [CacheAspect(10)]
        public IDataResult<Customer> GetCustomerByUserId(int userId)
        {
            var result = _customerDal.Get(c => c.UserId == userId);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result, Messages.CustomerListed);
            }

            return new ErrorDataResult<Customer>(null, Messages.CustomerNotExist);
        }

        [SecuredOperation("admin,customer.all,customer.list")]
        [CacheAspect(10)]
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.CustomerListed);
        }

        [SecuredOperation("admin,customer.all,customer.add")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }


        [SecuredOperation("admin,customer.all,customer.delete")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }



        [SecuredOperation("admin,customer.all,customer.update")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
