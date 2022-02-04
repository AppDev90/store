using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Store.ApplicationService.Common;
using Store.ApplicationService.Contract;
using Store.ApplicationService.Factory;
using Store.Core.Identity.Addresses;
using Store.Core.Identity.Addresses.Dto;
using Store.Core.Identity.Users;
using Store.Core.Identity.Users.Dto;
using Store.Core.Identity.Users.ServiceContract;
using System.Threading.Tasks;

namespace Store.ApplicationService.IdentityService.User
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, ITokenService tokenService, IClaimService claimService, IMapper mapper, ErrorFactory errorFactory)
            : base(errorFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _claimService = claimService;
            _mapper = mapper;
        }

        public async Task<AuthenticatedUserDto> LoginAsync(LoginDto loginDto)
        {
            //if (_claimService.IsUserAuthenticated())
            //{
            //    return await GetCurrentUserAsync();
            //}


            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                NotAuthorized.Throw("");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password
                , false);
            if (!result.Succeeded)
            {
                NotAuthorized.Throw("");
            }

            return CreateAuthenticatedUser(user);
        }

        public async Task<AuthenticatedUserDto> RegisterAsync(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result)
            {
                ValidationError.AddError("Email address is in use");
                ValidationError.Throw();
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                UnKnownError.Throw("Error in Registeration.");

            return CreateAuthenticatedUser(user);
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<AuthenticatedUserDto> GetCurrentUserAsync()
        {
            string email = _claimService.GetEmail();

            var user = await _userManager.FindByEmailAsync(email);

            return CreateAuthenticatedUser(user);
        }

        public async Task<AddressDto> GetCurrentUserAddressAsync()
        {
            string email = _claimService.GetEmail();

            var user = await _userManager.FindUerByEmailIncludingAddress(email);

            return MappToAddressDto(user.Address);
        }

        public async Task<AddressDto> UpdateAddress(AddressDto addressDto)
        {
            string email = _claimService.GetEmail();

            var user = await _userManager.FindUerByEmailIncludingAddress(email);

            user.Address = MappToAddress(addressDto);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                UnKnownError.Throw("problem in updating user.");

            return MappToAddressDto(user.Address);
        }

        private AuthenticatedUserDto CreateAuthenticatedUser(AppUser user)
        {
            return new AuthenticatedUserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        private AddressDto MappToAddressDto(Address address)
        {
            return _mapper.Map<AddressDto>(address);
        }

        private Address MappToAddress(AddressDto addressDto)
        {
            return _mapper.Map<Address>(addressDto);
        }

    }
}
