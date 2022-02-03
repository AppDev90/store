using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.Core.Identity.Users;
using Store.Infrastructure.Data;
using Store.Infrastructure.DataIdentity;
using System.Threading.Tasks;

namespace Store.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            MigrateAndSeedDb(host);
            await MigrateAndSeedIdentityDb(host);
            host.Run();
        }

        private static void MigrateAndSeedDb(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<StoreContextInitialWork>();
                var context = services.GetRequiredService<StoreDbContext>();

                StoreContextInitialWork.Migrate(context, logger);
                StoreContextInitialWork.SeedData(context, logger);
            }
        }

        private static async Task MigrateAndSeedIdentityDb(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<AppIdentityContextSeed>();
                var context = services.GetRequiredService<AppIdentityDbContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();

                AppIdentityContextSeed.Migrate(context, logger);
                await AppIdentityContextSeed.SeedData(userManager, logger);
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
