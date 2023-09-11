using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Identity
{
    public interface IIdentityService
    {
        Task<string> GenerateTokenAsync(User user);
        Task<User> GetUserAsync(string username);
        Task<IdentityResult> CreateUserAsync(string username, string email, string namesurname, string password);
        Task<bool> ChangePasswordAsync(string username, string currentPassword, string newPassword);
    }
}
