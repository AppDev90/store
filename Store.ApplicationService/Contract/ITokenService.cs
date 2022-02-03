
using Store.Core.Identity.Users;

namespace Store.ApplicationService.Contract
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
