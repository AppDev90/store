

namespace Store.Core.Identity.Users.Dto
{
    public class AuthenticatedUserDto
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
    }
}
