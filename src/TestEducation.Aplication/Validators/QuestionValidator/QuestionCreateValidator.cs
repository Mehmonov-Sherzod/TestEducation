using FluentValidation;
using TestEducation.Aplication.Models.Question;

namespace TestEducation.Aplication.Validators.QuestionValidator
{
    public class QuestionCreateValidator : AbstractValidator<CreateQuestionModel>
    {
        public QuestionCreateValidator()
        {
            RuleFor(q => q.QuestionText)
                .MinimumLength(1).WithMessage("Question title should have minimum 100 characters")
                .MaximumLength(200).WithMessage("Question title should have maximum 200 characters");
        }
    }
}
