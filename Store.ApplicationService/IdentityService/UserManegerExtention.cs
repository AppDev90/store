
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Core.Identity.Users;
using System.Threading.Tasks;

namespace Store.ApplicationService.IdentityService
{
    public static class UserManegerExtention
    {
        public static async Task<AppUser> FindUerByEmailIncludingAddress(this UserManager<AppUser> input, string email)
        {
            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
