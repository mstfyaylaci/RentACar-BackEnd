using Core.Entities.Concrete;
using Core.Entitites.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entityframework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentACar;Trusted_Connection=true");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=nozomi.proxy.rlwy.net;Port=43635;Database=railway;Username=postgres;Password=VbpxAijnjNwRKRmtLLwknDjDwifiwkyc;SSL Mode=Require;Trust Server Certificate=true;");
            }
        }

        //Veri tabanı kolanalrı yazmayı unutma

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<CustomerCreditCard> CustomerCreditCards { get; set; }

        public DbSet<Payment> Payments { get; set; }

    }
}
