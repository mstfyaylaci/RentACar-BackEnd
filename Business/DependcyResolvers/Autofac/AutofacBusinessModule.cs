using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependcyResolvers.Autofac
{   // startup ortamını sağlayacak olan class
    // - WebApı ye bağlı kalmamak için yapıyoruz
    // .Net e kendi alt yapını değil benim yazdığım AUtofac alt yapısını kullan dedik
    // ileride autofac yerine başka bir teknoloji kullanılmak isternirse Yeni bir DepencyResolvers/Yeniteknoloji.class oluştur
    // ve progrram.cs de ilgili yeri değiştir 
    public class AutofacBusinessModule:Module 
    {
        // uygulama ayağa kalktığında çalışacak
        protected override void Load(ContainerBuilder builder)
        {
            //Startup daki AddSingleTon a denk geliyor
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();// tek bir referans oluştur herkese onu ver
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();// tek bir referans oluştur herkese onu ver
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();// tek bir referans oluştur herkese onu ver
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();// tek bir referans oluştur herkese onu ver
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();// tek bir referans oluştur herkese onu ver
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();// tek bir referans oluştur herkese onu ver
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
