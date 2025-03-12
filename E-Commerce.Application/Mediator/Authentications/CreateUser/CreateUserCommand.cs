
using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.User;
using MediatR;

namespace E_Commerce.Application.Mediator.Authentications.CreateUser;

public class CreateUserCommand : UserBase, IRequest<LoginResponse>
{
    public string FullName { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}
