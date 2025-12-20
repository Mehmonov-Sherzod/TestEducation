using FluentValidation;
using TestEducation.Aplication.Models.Users;

namespace TestEducation.Aplication.Validators.UserValidator;

public class UserUpdateValidator : AbstractValidator<UpdateUserModel>
{
    public UserUpdateValidator()
    {
        RuleFor(u => u.FullName)
            .MinimumLength(3).WithMessage("User FullName should have minimum 3 characters")
            .MaximumLength(20).WithMessage("User FullName should have minimum 20 characters");

        RuleFor(u => u.Email)
            .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Email must be a valid Gmail address")
            .EmailAddress().WithMessage("EMAIL WRONG, TRY AGAIN");

        RuleFor(p => p.PhoneNumber)
               .Matches(@"^(90|91|93|94|95|97|98|99|33|88)\d{7}$")
               .WithMessage("Telefon raqam noto‘g‘ri");
    }
}
