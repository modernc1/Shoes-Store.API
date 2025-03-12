using AutoMapper;
using E_Commerce.Application.DTO.User;
using E_Commerce.Application.Interfaces.Logging;
using E_Commerce.Domain.Interfaces.Authentication;
using E_Commerce.Domain.Models.Identity;
using MediatR;
using System.Security.Claims;

namespace E_Commerce.Application.Mediator.Authentications.LoginUser
{
    internal class LoginUserCommandHandler(IUserManagement userManagement,
        ITokenManagement tokenManagement,
        IMapper mapper,
        IAppLogger<LoginUserCommandHandler> logger) : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("User Logging in");

            var user = mapper.Map<AppUser>(request);
            user.PasswordHash = request.Password;
            bool result = await userManagement.LoginUserAsync(user);

            if (!result) return new LoginResponse { Message = "Wrong Email/Password please try again" };

            //Get Claims
            var _user = await userManagement.GetUserByEmailAsync(request.Email);
            List<Claim> claims = await userManagement.GetUserClaimsAsync(_user!.Email!);

            //generate Token and refresh Token
            string jwtToken = tokenManagement.GenerateToken(claims);
            string refreshToken = tokenManagement.GetRefreshToken();

            //Delete old Refresh token & save tokens to Database
            int saveTokenResult = await tokenManagement.AddRefreshTokenAsync(_user.Id, refreshToken);
            if (saveTokenResult <= 0) return new LoginResponse { Message = "Internal Error Occured During Authorization" };

			return new LoginResponse { Success = true, Token = jwtToken,
                RefreshToken = refreshToken, FullName = _user.FullName,
                Email = _user.Email!, Role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value!};
        }
    }
}
