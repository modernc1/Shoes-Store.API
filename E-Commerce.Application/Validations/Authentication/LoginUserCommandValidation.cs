using E_Commerce.Application.DTO.User;
using E_Commerce.Application.Mediator.Authentications.LoginUser;
using FluentValidation;

namespace E_Commerce.Application.Validations.Authentication
{
    public class LoginUserCommandValidation : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Full Name is Required")
                .EmailAddress().WithMessage("Enter valid email address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }

}
