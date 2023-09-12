using ETicaretAPI.Application.Identity;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace ETicaretAPI.Infrastructure.Identity.Service
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;

        public IdentityService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            return "";
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> ChangePasswordAsync(string username, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return false;

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return result.Succeeded;
        }

        public async Task<IdentityResult> CreateUserAsync(string username, string email, string namesurname, string password)
        {
            var user = new User { Id = Guid.NewGuid().ToString(), UserName = username, Email = email, NameSurname = namesurname };
            IdentityResult identityResult = await _userManager.CreateAsync(user, password);

            return identityResult;
        }
    }
}
