using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                                 Id = ca.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.Dailyprice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                             };
                return result.ToList();
            }
        }
    }
}
