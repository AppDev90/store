

using Microsoft.AspNetCore.Http;
using Store.ApplicationService.Contract;
using Store.Core.Identity.Users;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Store.ApplicationService.AuthenticationsService
{
    public class ClaimService : IClaimService
    {
        private readonly ClaimsPrincipal _user;

        public ClaimService(IHttpContextAccessor context)
        {
            _user = context.HttpContext.User;
        }

        public ClaimsIdentity GetClaimsForToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };
            return new ClaimsIdentity(claims);
        }

        public string GetEmail()
        {
            return _user.FindFirstValue(ClaimTypes.Email);
        }

        public bool IsUserAuthenticated()
        {
            return _user.Identity.IsAuthenticated;

        }
    }
}
