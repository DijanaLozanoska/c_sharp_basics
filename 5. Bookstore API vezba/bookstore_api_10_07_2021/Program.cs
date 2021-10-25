using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_api_10_07_2021.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bookstore_api_10_07_2021
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
           {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured seeding the DB.");
                }
           }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //WebHost.CreateDefaultBuilder(args)
        //  .UseUrls("https://localhost:5002")
        //  .UseStartup<Startup>();
    }
}
