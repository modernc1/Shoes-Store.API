
using E_Commerce.Infrastructure.Data;
using E_Commerce.Domain.Interfaces.Authentication;
using E_Commerce.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_Commerce.Infrastructure.Repositories.Authentication
{
    internal class TokenManagement(AppDbContext context,
        IConfiguration configuration) : ITokenManagement
    {
        public async Task<int> AddRefreshTokenAsync(string userId, string refreshToken)
        {//user can only have one refresh token at the time

            var storedToken = await context.RefreshTokens.FirstOrDefaultAsync(r => r.UserId == userId);
            if (storedToken != null)
            {
                storedToken.Token = refreshToken;
            }
            else
            {
                context.RefreshTokens.Add(new RefreshToken
                {
                    UserId = userId,
                    Token = refreshToken
                });
            }
            return await context.SaveChangesAsync();
        }

        public string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));

            //create credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.Now.AddHours(2);
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetRefreshToken()
        {
            const int byteSize = 64;
            byte[] randomByte = new byte[byteSize];
            
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomByte);
            }

            string token = Convert.ToBase64String(randomByte); //if returned this line special characters will change whne sending token in route
            return WebUtility.UrlEncode(token);                //which will cause cause problems during validation
        }

        public List<Claim> GetUserClaimsFromTokenAsync(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);
            if(jwtToken !=  null) 
                return jwtToken.Claims.ToList();
            
            return new List<Claim>();
        }

        public async Task<string> GetUserIdByRefreshTokenAsync(string refreshToken) =>
            (await context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken))!.UserId;
        public async Task<int> UpdateRefreshTokenAsync(string userId, string refreshToken)
        {
            var user = await context.RefreshTokens.FirstOrDefaultAsync(_ => _.UserId == userId);
            if(user == null) return -1;
            user.Token = refreshToken;
            return await context.SaveChangesAsync();
        }

        public async Task<bool> ValidateRefreshTokenAsync(string refreshToken)
        {
            //check if the token is in db
            var TokenInDb = await context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == refreshToken);
            return TokenInDb != null;
        }
    }
}
