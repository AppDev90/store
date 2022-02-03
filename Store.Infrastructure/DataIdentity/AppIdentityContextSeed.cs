using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Core.Identity.Addresses;
using Store.Core.Identity.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.DataIdentity
{
    public class AppIdentityContextSeed
    {

        public static void Migrate(AppIdentityDbContext context, ILogger logger)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                LoggError(logger, "AppIdentityDbContext Migration Error!" + ex.Message);
            }

        }

        public static async Task SeedData(UserManager<AppUser> userManager, ILogger logger)
        {
            try
            {
                if (!await userManager.Users.AnyAsync())
                {
                    var user = new AppUser
                    {
                        DisplayName = "DisplayName",
                        Email = "test@email.com",
                        UserName = "UserName",
                        Address = new Address
                        {
                            FirstName = "FirstName",
                            LastName = "LastName",
                            Street = "Street",
                            City = "City",
                            State = "State",
                            Zipcode = "12345"
                        }
                    };

                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            catch (Exception ex)
            {
                LoggError(logger, "AppIdentityDbContext SeedDate Error! " + ex.Message);
            }
        }

        private static void LoggError(ILogger logger, string message)
        {
            logger.LogError(message);
        }
    }
}
