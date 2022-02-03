

using Store.Core.Identity.Users;
using System.Security.Claims;

namespace Store.ApplicationService.Contract
{
    public interface IClaimService
    {
        string GetEmail();
        bool IsUserAuthenticated();
        ClaimsIdentity GetClaimsForToken(AppUser user);

    }
}
