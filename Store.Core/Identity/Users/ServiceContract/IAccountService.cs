
using Store.Core.Identity.Addresses.Dto;
using Store.Core.Identity.Users.Dto;
using System.Threading.Tasks;

namespace Store.Core.Identity.Users.ServiceContract
{
    public interface IAccountService
    {
        Task<AuthenticatedUserDto> LoginAsync(LoginDto loginDto);
        Task<AuthenticatedUserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> CheckEmailExistsAsync(string email);
        Task<AuthenticatedUserDto> GetCurrentUserAsync();
        Task<AddressDto> GetCurrentUserAddressAsync();
        Task<AddressDto> UpdateAddress(AddressDto addressDto);
    }
}
