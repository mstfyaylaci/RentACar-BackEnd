using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Result;

namespace Business.Concrete
{
    public class FindexScoreManager : IFindexScoreService
    {
        private ICustomerService _customerService;
        private ICarService _carService;

        public FindexScoreManager(ICustomerService customerService, ICarService carService)
        {
            _customerService = customerService;
            _carService = carService;
        }

        public IDataResult<int> GetCarMinFindexScore(int carId)
        {
            var carResult = _carService.GetById(carId);
            if (!carResult.Success)
            {
                return new ErrorDataResult<int>(-1, carResult.Message);
            }

            return new SuccessDataResult<int>(carResult.Data.MinFindexScore);
        }

        public IDataResult<int> GetCustomerFindexScore(int customerId)
        {
            var customerResult = IsCustomerIdExist(customerId);
            if (customerResult.Success)
            {
                Random random = new Random();
                int randomFindexScore = Convert.ToInt16(random.Next(0, 1900));
                return new SuccessDataResult<int>(randomFindexScore);
            }
            return new ErrorDataResult<int>(-1, customerResult.Message);
        }

        private IResult IsCustomerIdExist(int customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Success)
            {
                return new SuccessResult();
            }

            return new ErrorResult(result.Message);
        }
    }
}
