using E_Commerce.Domain.Models.Identity;
using System.Security.Claims;

namespace E_Commerce.Domain.Interfaces.Authentication
{
    public interface IUserManagement
    {
        Task<bool> CreateUserAsync(AppUser user);
        Task<bool> LoginUserAsync(AppUser user);
        Task<AppUser?> GetUserByEmailAsync(string email);
        Task<AppUser> GetUserByIdAsync(string id);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<int> RemoveUserByEmailAsync(string email);
        Task<List<Claim>> GetUserClaimsAsync(string email);
        string? GetCurrentUserId();
    }

}
