using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class EfRentalDal : EfEntityrepository<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from r in context.Rentals
                             join ca in context.Cars
                                on r.CarId equals ca.Id
                             join cu in context.Customers
                                on r.CustomerId equals cu.Id
                             join u in context.Users
                                on cu.UserId equals u.Id
                             join b in context.Brands
                                on ca.BrandId equals b.Id
                             join p in context.Payments
                                on r.PaymentId equals p.Id


                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 CarFullName = $"{b.BrandName} {ca.CarName}",
                                 CustomerId = r.CustomerId,
                                 CustomerName = $"{u.FirstName} {u.LastName}",
                                 RentalDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = ca.DailyPrice,
                                 DeliveryStatus = r.DeliveryStatus,
                                 PaymentId = r.PaymentId,
                                 PaymentDate = p.PaymentDate,
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
            }
        }

        public void CarDeliver(int rentalId)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var updateRental = context.Rentals.FirstOrDefault(r => r.Id == rentalId);
                updateRental.DeliveryStatus = false;
                context.SaveChanges();
            }
        }

        public List<RentalDetailDto> GetRentalsDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join ca in context.Cars
                                on r.CarId equals ca.Id
                             join cu in context.Customers
                                on r.CustomerId equals cu.Id
                             join u in context.Users
                                on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 CarFullName = ca.CarName,
                                 CustomerId = r.CustomerId,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentalDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice=ca.DailyPrice,
                                 DeliveryStatus = r.DeliveryStatus
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
            }
           
        }

       
    }
}
