using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
     class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();

            //ColorTest();

            //CarTest();


            //InMemoryTest();


            //CustomerTest();

            //RentalTest();

            //UserTest();

            //RentalTest2();

        }

        private static void RentalTest2()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental
            {

                ReturnDate = null,
                RentDate = DateTime.Now,
                CustomerId = 11,
                CarId = 8,

            });


            //rentalManager.CarDeliver(12); //Araç geri teslim fonk


            var result = rentalManager.GetRentalDetails();

            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarName + "-" + rental.CustomerName + "-" + rental.RentalDate + "-" + rental.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            //userManager.Add(new User
            //{
            //    FirstName="Apo",
            //    LastName="Göcen",
            //    Email="apo@gmail.com",
            //    Password="asfg"
            //});

            //userManager.Update(new User
            //{
            //    Id=5,
            //    FirstName = "Abdülkadir",
            //    LastName = "Göçen",
            //    Email = "apo@gmail.com",
            //    Password = "asf123g"
            //});

            //userManager.Delete(new User
            //{
            //    Id = 5,

            //});


            var result = userManager.GetAll();

            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName);
                }
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //Console.WriteLine(rentalManager.GetById(1).Data.RentDate);

            //rentalManager.Add(new Rental
            //{
            //    RentDate = DateTime.Now,
            //    CustomerId=13,
            //    CarId=3,

            //});

            //rentalManager.Update(new Rental
            //{
            //    Id = 9,
            //    RentDate = new DateTime(2024,2,5),
            //    ReturnDate= new DateTime(2024, 2, 7),
            //    CustomerId = 13,
            //    CarId = 3,

            //});

            //rentalManager.Delete(new Rental
            //{
            //    Id = 10,


            //});

            var result = rentalManager.GetAll();

            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.Id + " ");
                }
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //customerManager.Add(new Customer
            //{
            //    CompanyName = "Test",
            //    UserId = 1,
            //});

            //customerManager.Update(new Customer
            //{
            //    Id = 15,
            //    UserId = 2,
            //    CompanyName = "Test2"
            //});
            //customerManager.Delete(new Customer
            //{
            //    Id = 15,

            //});

            //Console.WriteLine(customerManager.GetById(11).Data.CompanyName);


            var result = customerManager.GetAll();

            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car() { Id = 6, BrandId = 4, ColorId = 3, ModelYear = 2021, Dailyprice = 270, Description = "6 km yeni araç" });

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id);
            //}

            List<Brand> brands = new List<Brand>
            {
                new Brand(){Id=1,BrandName="BMW"},
                new Brand(){Id=2,BrandName="Mercedes"},
            };

            List<Car> cars = new List<Car>
            {
                new Car() {Id=1 ,BrandId=1,ColorId=1,ModelYear=2023,Dailyprice=200,Description="Ford "},
                new Car() {Id=2 ,BrandId=2,ColorId=2,ModelYear=2024,Dailyprice=220,Description="Skoda araç"},
                new Car() {Id=3 ,BrandId=1,ColorId=2,ModelYear=2024,Dailyprice=220,Description="Bmw araç1"},
                new Car() {Id=4 ,BrandId=2,ColorId=3,ModelYear=2022,Dailyprice=250,Description="Mercedes araç2"},
                new Car() {Id=5 ,BrandId=2,ColorId=3,ModelYear=2021,Dailyprice=270,Description="Dacia araç3"},
            };

            //var result = cars.FindAll(c => c.Description.Contains("araç")).OrderBy(c => c.Dailyprice).ThenBy(c => c.Description);

            //foreach (var car in result)
            //{
            //    Console.WriteLine(car.Description);
            //}

            //var result = from c in cars
            //             join b in brands  //car ve brand tablolalarındaki her bir nesneyi join et . neye göre?
            //             on c.BrandId equals b.Id           // brandId ve b.id ye göre  
            //             where c.Dailyprice > 250
            //             select new CarDto { Id = c.Id, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.Dailyprice, Description = c.Description };

            //foreach (var carDto in result)
            //{
            //    Console.WriteLine(carDto.Id + " " + carDto.BrandName);
            //}
        }

        private static void BrandTest()
        {
            BrandManager brands = new BrandManager(new EfBrandDal());

           // Console.WriteLine(brands.GetById(1).BrandName); 
            //brands.Add(new Brand { BrandName="Dodge"});
            //brands.Update(new Brand { Id = 23, BrandName = "Dodgee" });
            //brands.Delete(new Brand { Id = 23 });

            var result=brands.GetAll();

            if (result.Success==true)
            {
                foreach (var brand in result.Data )
                {
                    Console.WriteLine(brand.BrandName);
                }
            }

            
        }

        private static void ColorTest()
        {
            ColorManager colors = new ColorManager(new EfColorDal());

            //colors.Add(new Color { ColorName = "Vizon Kahve" });
            //colors.Update(new Color { Id = 11, ColorName = "Vizonn Kahve" });
            //colors.Delete(new Color { Id = 11 });

            var result=colors.GetAll();

            if (result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }

            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result=carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "----" + car.BrandName + "---" + car.ColorName + "---" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }

    

}
