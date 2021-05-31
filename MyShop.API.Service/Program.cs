using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyShop.Persistance.Database;

namespace MyShop.API.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            RunSeeding(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void RunSeeding(IHost host)
        {
            var scopeFacory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFacory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<MyShopDataSeeder>();
                seeder?.Seed();
            }
        }
    }
}