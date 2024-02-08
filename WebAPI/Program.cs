using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependcyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())// .NetCora senin alt yap�nda IOC var ama sen Autofaci kullan
                .ConfigureContainer<ContainerBuilder>(buider =>
                {
                    buider.RegisterModule(new AutofacBusinessModule());// ba�ka bir IOC container kullan�lmak istenirse yap�lacak hareket
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
