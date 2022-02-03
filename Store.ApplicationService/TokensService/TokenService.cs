

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.ApplicationService.Contract;
using Store.Core.Identity.Users;
using Store.Core.Identity.Users.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.ApplicationService.TokensService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IClaimService _claimService;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config, IClaimService claimService)
        {
            _config = config;
            _claimService = claimService;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public string CreateToken(AppUser user)
        {

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = _claimService.GetClaimsForToken(user),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
