using E_Commerce.Domain.Models.Identity;
using System.Security.Claims;

namespace E_Commerce.Domain.Interfaces.Authentication
{
    public interface ITokenManagement
    {
        string GetRefreshToken();
        string GenerateToken(List<Claim> claims);

        List<Claim> GetUserClaimsFromTokenAsync(string token);
        Task<bool> ValidateRefreshTokenAsync(string refreshToken);
        Task<string> GetUserIdByRefreshTokenAsync(string refreshToken);
        Task<int> AddRefreshTokenAsync(string userId, string refreshToken);
        Task<int> UpdateRefreshTokenAsync(string userId, string refreshToken);        
    }

}
