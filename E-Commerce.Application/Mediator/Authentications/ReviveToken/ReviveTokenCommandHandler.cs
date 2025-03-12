
using E_Commerce.Application.DTO.User;
using E_Commerce.Application.Interfaces.Logging;
using E_Commerce.Domain.Interfaces.Authentication;
using MediatR;

namespace E_Commerce.Application.Mediator.Authentications.ReviveToken;

internal class ReviveTokenCommandHandler(ITokenManagement tokenManagement,
    IUserManagement userManagement,
    IAppLogger<ReviveTokenCommandHandler> logger) : IRequestHandler<ReviveTokenCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(ReviveTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            //validate refresh token in database
            logger.LogInformation($"Revive Token");

            var isValid = await tokenManagement.ValidateRefreshTokenAsync(request.RefreshToken);
            if (!isValid) return new LoginResponse { Message = "Invalid Token" };

            //retrive userId from database
            var _userId = await tokenManagement.GetUserIdByRefreshTokenAsync(request.RefreshToken);

            //retrive user from database
            var _user = await userManagement.GetUserByIdAsync(_userId);

            //get claims
            var claims = await userManagement.GetUserClaimsAsync(_user!.Email!);

            //generate new token and refresh token
            var newjwtToken = tokenManagement.GenerateToken(claims!);
            var newRefreshToken = tokenManagement.GetRefreshToken();


            //update refresh token in database
            int isUpdatedToken = await tokenManagement.UpdateRefreshTokenAsync(_user.Id, newRefreshToken);
            if (isUpdatedToken <= 0) return new LoginResponse { Message = "Failed to update token" };

            return new LoginResponse { Success = true, Token = newjwtToken, RefreshToken = newRefreshToken };
        } catch (Exception ex)
        {
            logger.LogError(ex, $"Error Occured during Revive Token {request.RefreshToken}");
            return new LoginResponse { Success = false, Message = "Internal Error Occured" };

        }
    }
}
