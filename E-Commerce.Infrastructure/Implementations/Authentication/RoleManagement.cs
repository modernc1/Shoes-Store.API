using E_Commerce.Domain.Interfaces.Authentication;
using E_Commerce.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Infrastructure.Repositories.Authentication
{
    internal class RoleManagement(UserManager<AppUser> userManager) : IRoleManagement
    {
        public async Task<bool> AddUserToRoleAsync(AppUser user, string roleName) =>
            (await userManager.AddToRoleAsync(user, roleName)).Succeeded;

        public async Task<string?> GetUserRoleAsync(string userEmail)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            return (await userManager.GetRolesAsync(user!)).FirstOrDefault();
        }
    }
}
