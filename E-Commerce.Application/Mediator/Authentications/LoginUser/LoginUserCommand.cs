using E_Commerce.Application.DTO.User;
using MediatR;


namespace E_Commerce.Application.Mediator.Authentications.LoginUser
{
    public class LoginUserCommand : UserBase, IRequest<LoginResponse>
    {
    }
}
