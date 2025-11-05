using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TestEducation.Aplication.Models.UserEmail;

namespace TestEducation.Aplication.Validators.UserValidator
{
    public class UserResetValidator :AbstractValidator<UserEmailReset>
    {
        public UserResetValidator()
        {
            RuleFor(p => p.NewPassword)
                  .MinimumLength(8).WithMessage("must be at least 8 characters")
                  .Matches("[A-Z]").WithMessage("Parolda kamida bitta katta harf bo‘lishi kerak.")
                  .Matches("[a-z]").WithMessage("Parolda kamida bitta kichik harf bo‘lishi kerak.")
                  .Matches("[0-9]").WithMessage("Parolda kamida bitta raqam bo‘lishi kerak.");

            RuleFor(x => x.Email)
                .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Email must be a valid Gmail address")
                .EmailAddress().WithMessage("EMAIL WRONG, TRY AGAIN");
        }
    }
}
