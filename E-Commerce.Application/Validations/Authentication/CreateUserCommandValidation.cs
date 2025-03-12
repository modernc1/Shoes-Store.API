using E_Commerce.Application.DTO.User;
using E_Commerce.Application.Mediator.Authentications.CreateUser;
using E_Commerce.Application.Mediator.Categories.Commands.CreateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Validations.Authentication
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full Name is Required");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Full Name is Required")
                .EmailAddress().WithMessage("Enter valid email address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least 1 uppercase character")
                .Matches(@"[a-z]").WithMessage("Password must contain at least 1 lowercase character")
                .Matches(@"[\d]").WithMessage("Password must contain at least 1 number");

            RuleFor(x => x.ConfirmPassword)
                .Matches(x => x.Password).WithMessage("Passwords do not match");    
        }
    }

}
