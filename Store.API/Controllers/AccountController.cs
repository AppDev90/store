using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Identity.Addresses.Dto;
using Store.Core.Identity.Users.Dto;
using Store.Core.Identity.Users.ServiceContract;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticatedUserDto>> Login(LoginDto loginDto)
        {
            return await _accountService.LoginAsync(loginDto);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthenticatedUserDto>> Register(RegisterDto registerDto)
        {
            return await _accountService.RegisterAsync(registerDto);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<AuthenticatedUserDto>> GetCurrentUser()
        {
            return await _accountService.GetCurrentUserAsync();
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _accountService.CheckEmailExistsAsync(email);
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            return await _accountService.GetCurrentUserAddressAsync();
        }

        [Authorize]
        [HttpPost("address")]
        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto addressDto)
        {
            return await _accountService.UpdateAddress(addressDto);
        }

    }
}
