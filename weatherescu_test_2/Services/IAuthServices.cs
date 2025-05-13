
using Microsoft.AspNetCore.Identity;

namespace weatherescu_test_2.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(string email, string password);
        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
        Task LogoutAsync();
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName);
        Task<bool> IsInRoleAsync(string userId, string roleName);
        Task<IdentityUser> FindByEmailAsync(string email);
    }
}
