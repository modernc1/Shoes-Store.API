using E_Commerce.Application.DTO.User;
using MediatR;


namespace E_Commerce.Application.Mediator.Authentications.ReviveToken;

public class ReviveTokenCommand : IRequest<LoginResponse>
{
    public string RefreshToken { get; set; } = default!;
}
