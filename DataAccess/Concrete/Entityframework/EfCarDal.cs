using Core.DataAccess.EntitiyFramework;
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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
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
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 CarImages = (from ci in context.CarImages
                                              where ci.CarId == ca.Id
                                              select new CarImage
                                              {
                                                  Id = ci.Id,
                                                  CarId = ci.CarId,
                                                  Date = ci.Date,
                                                  ImagePath = ci.ImagePath,
                                              }).ToList().Count == 0
                                                        ? new List<CarImage> { new CarImage { Id = -1, CarId = ca.Id, Date = DateTime.Now, ImagePath = "Default.png" } }
                                                        : (from ci in context.CarImages
                                                           where ca.Id == ci.CarId
                                                           select new CarImage
                                                           {
                                                               Id = ci.Id,
                                                               CarId = ci.CarId,
                                                               Date = ci.Date,
                                                               ImagePath = ci.ImagePath,
                                                           }).ToList()
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();

            }
        }


        




    }
}
