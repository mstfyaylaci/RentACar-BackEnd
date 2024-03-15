﻿using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfCarDal : EfEntityrepository<Car, RentACarContext>, ICarDal
    {


        //public void Add(Car entity)
        //{
        //    using (RentACarContext context=new RentACarContext())
        //    {
        //        var addedEntity = context.Entry(entity);            // Referansı yakala
        //        addedEntity.State = EntityState.Added;             // yakalanan referansa ekle
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var deletedEntity = context.Entry(entity);            // Referansı yakala
        //        deletedEntity.State = EntityState.Deleted;             // yakalanan referansa sil
        //        context.SaveChanges();
        //    }
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //       return context.Set<Car>().SingleOrDefault(filter);

        //    }
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //       return filter==null                                  // filtre null ise(true)=1

        //            ? context.Set<Car>().ToList()                   // 1- arabları listele
        //            : context.Set<Car>().Where(filter).ToList();   // 2-Filtreli arabalrı listele     

        //    }
        //}

        //public void Update(Car entity)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var updatedEntity = context.Entry(entity);            // Referansı yakala
        //        updatedEntity.State = EntityState.Modified;             // yakalanan referansa güncelle
        //        context.SaveChanges();
        //    }
        //}
        //public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from ca in context.Cars
        //                     join b in context.Brands
        //                     on ca.BrandId equals b.Id
        //                     join co in context.Colors
        //                     on ca.ColorId equals co.Id
        //                     select new CarDetailDto
        //                     {
        //                         CarId = ca.Id,
        //                         CarName = ca.CarName,
        //                         BrandId = b.Id,
        //                         ColorId = co.Id,
        //                         BrandName = b.BrandName,
        //                         ColorName = co.ColorName,
        //                         DailyPrice = ca.DailyPrice,
        //                         Description = ca.Description,
        //                         ModelYear = ca.ModelYear,
        //                     };
        //        return filter==null
        //            ? result.ToList()
        //            :result.Where(filter).ToList();
        //    }
        //}


        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 ImagePath=(from ci in context.CarImages where ci.CarId==ca.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarDetailsId(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             where ca.Id== carId
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == ca.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarByBrandIdDetails(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             where b.Id==brandId
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == ca.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarByColorIdDetails(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             where co.Id==colorId
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == ca.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             where ca.BrandId == brandId && ca.ColorId == colorId
                             select new CarDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == ca.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }

        }
    }
}
