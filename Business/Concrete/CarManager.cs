using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validaton;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }






        //--------------------------------------------Post---------------------------------------------------


        //[SecuredOperation("car.add,admin")]
        [ValidationAspect (typeof(CarValidator))] // aspect
                                                  //[CacheRemoveAspect("ICarService.Get")]
                                                  //public IResult Add(Car car)
                                                  //{

        //    _carDal.Add(car);
        //    return new SuccessResult(Messages.CarAdded);


        //}

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))] // aspect
        //[CacheRemoveAspect("ICarService.Get")]    
        public IDataResult<int> Add(Car car)
        {
            _carDal.Add(car);

            if (car.Id > 0) // EF Core, ekleme sonrası ID'yi otomatik set eder
            {
                return new SuccessDataResult<int>(car.Id, Messages.CarAdded);
            }

            return new ErrorDataResult<int>(-1, "Araç eklenirken hata oluştu");
        }








        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICar.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarsUpdated);
        }

        public IResult Delete(Car car)
        {

            // 1️⃣ Önce aracın veritabanında olup olmadığını kontrol et
            var carToDelete = _carDal.Get(c => c.Id == car.Id);
            if (carToDelete == null)
            {
                return new ErrorResult("Silmek istediğiniz araç bulunamadı.");
            }

            _carImageService.DeleteAllImageCarId(car.Id);

            // 4️⃣ Son olarak aracı sil
            _carDal.Delete(car);

            return new SuccessResult();
        }




        //---------------------------------------------Get------------------------------------
        //[CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        //[CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        
        

        //---------------------------------------------------------CarDetail Get----------------------------------------

        //[CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Message.MainteneanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<CarDetailDto> GetCarDetailsId(int id)
        {
           return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c=>c.Id==id).SingleOrDefault());

        }

        public IDataResult<List<CarDetailDto>> GetCarByBrandIdDetails(int brandId)
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarByColorIdDetails(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.BrandId==brandId && c.ColorId==colorId));
        }

       



        //İş kuralları 
    }
}
