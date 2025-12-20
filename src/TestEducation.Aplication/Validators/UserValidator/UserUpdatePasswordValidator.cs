using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TestEducation.Aplication.Models.Users;

namespace TestEducation.Aplication.Validators.UserValidator
{
    public class UserUpdatePasswordValidator : AbstractValidator<UpdateUserPassword>
    {
        public UserUpdatePasswordValidator()
        {
            RuleFor(p => p.OldPassword)
                .MinimumLength(8).WithMessage("must be at least 8 characters")
                .Matches("[A-Z]").WithMessage("Parolda kamida bitta katta harf bo‘lishi kerak.")
                .Matches("[a-z]").WithMessage("Parolda kamida bitta kichik harf bo‘lishi kerak.")
                .Matches("[0-9]").WithMessage("Parolda kamida bitta raqam bo‘lishi kerak.");


            RuleFor(p => p.NewPassword)
                 .MinimumLength(8).WithMessage("must be at least 8 characters")
                 .Matches("[A-Z]").WithMessage("Parolda kamida bitta katta harf bo‘lishi kerak.")
                 .Matches("[a-z]").WithMessage("Parolda kamida bitta kichik harf bo‘lishi kerak.")
                 .Matches("[0-9]").WithMessage("Parolda kamida bitta raqam bo‘lishi kerak.");

        }
    }
}
