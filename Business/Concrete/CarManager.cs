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




        //---------------------------------------------Get------------------------------------
        //[SecuredOperation("admin,car.all,car.list")]
        [CacheAspect(10)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        //[SecuredOperation("admin,car.all,car.list")]
        [CacheAspect(10)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }


        [SecuredOperation("admin,car.all,car.list")]
        [CacheAspect(10)]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }


        [SecuredOperation("admin,car.all,car.list")]
        [CacheAspect(10)]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }



        //---------------------------------------------------------CarDetail Get----------------------------------------

        //[CacheAspect]
        //[PerformanceAspect(5)]
        [CacheAspect(10)]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Message.MainteneanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect(10)]
        public IDataResult<CarDetailDto> GetCarDetailsId(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c => c.Id == id).SingleOrDefault());

        }

        //[SecuredOperation("admin,car.all,car.list")]
        [CacheAspect(10)]
        public IDataResult<List<CarDetailDto>> GetCarByBrandIdDetails(int brandId)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }


        //[SecuredOperation("admin,car.all,car.list")]
        [CacheAspect(10)]
        public IDataResult<List<CarDetailDto>> GetCarByColorIdDetails(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }


        //[SecuredOperation("admin,car.all,car.list")]
        [CacheAspect(10)]
        public IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId));
        }





        //--------------------------------------------Post---------------------------------------------------

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))] // aspect
        [CacheRemoveAspect("ICarService.Get")]    
        public IDataResult<int> Add(Car car)
        {
            _carDal.Add(car);

            if (car.Id > 0) // EF Core, ekleme sonrası ID'yi otomatik set eder
            {
                return new SuccessDataResult<int>(car.Id, Messages.CarAdded);
            }

            return new ErrorDataResult<int>(-1, "Araç eklenirken hata oluştu");
        }








        [SecuredOperation("car.update")]
        [ValidationAspect(typeof(CarValidator))] // aspect
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarsUpdated);
        }


        [SecuredOperation("admin,car.all,car.delete")]
        [CacheRemoveAspect("ICarService.Get")]
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



        //İş kuralları 
    }
}
