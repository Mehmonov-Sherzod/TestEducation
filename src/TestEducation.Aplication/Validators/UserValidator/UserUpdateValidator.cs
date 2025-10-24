using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TestEducation.Aplication.Models.Users;

namespace TestEducation.Aplication.Validators.UserValidator
{
    public class UserUpdateValidator : AbstractValidator<UpdateUserModel>
    {
        public UserUpdateValidator()
        {
            RuleFor(u => u.FullName)
               .MinimumLength(3)
                   .WithMessage("User FullName should have minimum 3 characters")
               .MaximumLength(20)
                   .WithMessage("User FullName should have minimum 20 characters");

            RuleFor(u => u.Email).
                Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$")
                    .WithMessage("Email must be a valid Gmail address")
                .Matches(@"^[a-zA-Z0-9._%+-]+@iclaude\.com$")
                .EmailAddress()
                    .WithMessage("EMAIL WRONG, TRY AGAIN");


            RuleFor(p => p.Password)
                .MinimumLength(8)
                    .WithMessage("must be at least 8 characters")
                .Matches("[A-Z]")
                    .WithMessage("Parolda kamida bitta katta harf bo‘lishi kerak.")
                .Matches("[a-z]")
                    .WithMessage("Parolda kamida bitta kichik harf bo‘lishi kerak.")
                .Matches("[0-9]")
                    .WithMessage("Parolda kamida bitta raqam bo‘lishi kerak.");
        }
    }
}
