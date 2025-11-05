using FluentValidation;
using TestEducation.Aplication.Models.UserEmail;

namespace TestEducation.Aplication.Validators.UserValidator
{
    public class UserForgotValidator : AbstractValidator<UserEmailForgot>
    {
        public UserForgotValidator()
        {
            RuleFor(x => x.Email)
                .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Email must be a valid Gmail address")
                .EmailAddress().WithMessage("EMAIL WRONG, TRY AGAIN");
        }
    }
}
