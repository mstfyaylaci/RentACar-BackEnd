using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car() {Id=1 ,BrandId=1,ColorId=1,ModelYear=2023,DailyPrice=200,Description="0 km yeni araç"},
                new Car() {Id=2 ,BrandId=2,ColorId=2,ModelYear=2024,DailyPrice=220,Description="0 km yeni araç"},
                new Car() {Id=3 ,BrandId=3,ColorId=2,ModelYear=2024,DailyPrice=230,Description="0 km yeni araç"},
                new Car() {Id=4 ,BrandId=2,ColorId=3,ModelYear=2022,DailyPrice=250,Description="0 km yeni araç"},
                new Car() {Id=5 ,BrandId=4,ColorId=3,ModelYear=2021,DailyPrice=270,Description="0 km yeni araç"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car deleteCar=_cars.SingleOrDefault(c=>c.Id==car.Id);

            _cars.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.Id==id).ToList();
        }

        public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByBrandIdDetails(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByColorIdDetails(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsId(int carId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updateCar=_cars.SingleOrDefault(c=> c.Id==car.Id);
            car.BrandId= updateCar.BrandId;
            car.ColorId= updateCar.ColorId;
            car.DailyPrice = updateCar.DailyPrice;
            car.Description= updateCar.Description;
        }
    }
}
