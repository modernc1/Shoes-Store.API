

using AutoMapper;
using E_Commerce.Application.DTO;
using E_Commerce.Application.DTO.User;
using E_Commerce.Application.Interfaces.Logging;
using E_Commerce.Application.Mediator.Authentications.LoginUser;
using E_Commerce.Domain.Interfaces.Authentication;
using E_Commerce.Domain.Models.Identity;
using E_Commerce.Domain.Static;
using MediatR;

namespace E_Commerce.Application.Mediator.Authentications.CreateUser
{
    internal class CreateUserCommandHandler(IUserManagement userManagement,
        IRoleManagement roleManagement,
        IAppLogger<CreateUserCommandHandler> logger,
        IMapper mapper,
        IMediator mediator) : IRequestHandler<CreateUserCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new User");

            var newUser = mapper.Map<AppUser>(request);
            newUser.UserName = request.Email;
            newUser.PasswordHash = request.Password; //the identity system will hash pass and assign the new value to it
            
            var result = await userManagement.CreateUserAsync(newUser);

            if (!result) return new LoginResponse { Success = false, Message = "This email is already registered" };


            //assign role to the User
            var _user = await userManagement.GetUserByEmailAsync(request.Email);
            bool isRoleAssigned = await roleManagement.AddUserToRoleAsync(_user!, StaticData.UserRole);

            if (!isRoleAssigned)
            {//if not assigned we need to (rollback) remove user from db
                int isRemoved = await userManagement.RemoveUserByEmailAsync(request.Email);
                if(isRemoved <= 0)
                {
                    logger.LogError(new Exception($"User with email {_user!.Email} failed to remove as result of role assigning issue"),
                        "User couldn't assigned to role");
                    return new LoginResponse { Success = false, Message = "Error occured during creating the account" };
                }
            }

            //Verify Email logic
            /////
            var loginresponse = await mediator.Send(new LoginUserCommand { Email = request.Email, Password = request.Password });
            return loginresponse;
        }
    }
}
