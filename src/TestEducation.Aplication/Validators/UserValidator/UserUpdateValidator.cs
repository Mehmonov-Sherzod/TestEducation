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
               .MinimumLength(3).WithMessage("User FullName should have minimum 3 characters")
               .MaximumLength(20).WithMessage("User FullName should have minimum 20 characters");

            RuleFor(u => u.Email)
                .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Email must be a valid Gmail address")
                //.Matches(@"^[a-zA-Z0-9._%+-]+@iclaude\.com$").WithMessage("Email must be a valid iclaude address")
                .EmailAddress().WithMessage("EMAIL WRONG, TRY AGAIN");

        }
    }
}
