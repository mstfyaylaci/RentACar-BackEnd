﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Business;
using DataAccess.Concrete.Entityframework;
using System.IO;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validaton;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [SecuredOperation("admin,carimage.all,carimage.list")]
        [CacheAspect(10)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [SecuredOperation("admin,carimage.all,carimage.list")]
        [CacheAspect(10)]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImage(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetCarImageDefault(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }


        [SecuredOperation("admin,carimage.all,carimage.list")]
        [CacheAspect(10)]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }



        [SecuredOperation("admin,carimage.all,carimage.add")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (result!=null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Upload(file,PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi");
        }


        [SecuredOperation("admin,carimage.all,carimage.delete")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(CarImage carImage)
        {

            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin,carimage.all,carimage.delete")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult DeleteAllImageCarId(int carId)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == carId);

            if (carImages == null || !carImages.Any())
            {
                return new ErrorResult("No images found for the specified car.");
            }

            foreach (var image in carImages)
            {

              Delete(image);

            }

            return new SuccessResult("All images for the specified car have been successfully deleted.");
        }


        [SecuredOperation("admin,carimage.all,carimage.update")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result=_carImageDal.GetAll(c=>c.CarId==carId).Count;

            if (result>=5)
            {
                return new ErrorResult("Bir arabanın en fazla 5 resmi olabilir");
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImage(int carId)
        {
            var result=_carImageDal.GetAll(c=>c.CarId== carId).Count;

            if (result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }  

        private IDataResult<List<CarImage>> GetCarImageDefault(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = "Default.png"
            });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

       
    }
    
}
