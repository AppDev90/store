
using Microsoft.AspNetCore.Identity;
using Store.Core.Identity.Addresses;

namespace Store.Core.Identity.Users
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public Address Address { get; set; }
    }
}
