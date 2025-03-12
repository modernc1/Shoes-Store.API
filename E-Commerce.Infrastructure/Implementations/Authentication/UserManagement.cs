
using E_Commerce.Infrastructure.Data;
using E_Commerce.Domain.Interfaces.Authentication;
using E_Commerce.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Infrastructure.Implementations.Authentication
{
    internal class UserManagement(IRoleManagement roleManagement,
        UserManager<AppUser> userManager,
        AppDbContext context,
        IHttpContextAccessor httpContextAccessor) : IUserManagement
    {
        public async Task<bool> CreateUserAsync(AppUser user)
        {
            //check is email exist in Db
            AppUser? _user = await GetUserByEmailAsync(user.Email!);
            if (_user == null)
            {
                //create User
                var result = (await userManager.CreateAsync(user, user.PasswordHash!)).Succeeded;
                return result;
            }

            return false;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync() => await context.Users.ToListAsync();

        public async Task<AppUser?> GetUserByEmailAsync(string email) => await userManager.FindByEmailAsync(email);

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user!;
        }

        public async Task<List<Claim>> GetUserClaimsAsync(string email)
        {
            var _user = await GetUserByEmailAsync(email);
            string? roleName = await roleManagement.GetUserRoleAsync(_user!.Email!);
            
            List<Claim> claims =
            [
                new Claim("FullName", _user.FullName),
                new Claim(ClaimTypes.NameIdentifier, _user.Id),
                new Claim(ClaimTypes.Email, _user.Email!),
                new Claim(ClaimTypes.Role, roleName!)
            ];

            return claims;
        }

        public async Task<bool> LoginUserAsync(AppUser user)
        {
            //check user in database
            var userFromDb = await GetUserByEmailAsync(user!.Email!);
            if (userFromDb == null) return false;

            //check user role
            string? roleName = await roleManagement.GetUserRoleAsync(userFromDb.Email!);
            if(string.IsNullOrEmpty(roleName)) return false;

            //check password                         
            return await userManager.CheckPasswordAsync(userFromDb, user.PasswordHash!);
        }

        public async Task<int> RemoveUserByEmailAsync(string email)
        {
            var user = context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null) return 0;

            context.Users.Remove(user);

            return await context.SaveChangesAsync();

        }
        
        public string? GetCurrentUserId()
        {
            var User = httpContextAccessor.HttpContext?.User;

            if(User == null) return null;

            if(User.Identity == null || !User.Identity.IsAuthenticated) return null;

            var UserId = User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;

            return UserId.ToString();
        }
    }
}
