using FluentValidation;
using TestEducation.Aplication.Models.Question;

namespace TestEducation.Aplication.Validators.QuestionValidator
{
    public class QuestionUpdateValidator : AbstractValidator<UpdateQuestionAnswerModel>
    {
        public QuestionUpdateValidator()
        {
            RuleFor(q => q.QuestionText)
                   .MinimumLength(5).WithMessage("Question title should have minimum 5 characters")
                   .MaximumLength(100).WithMessage("Question title should have maximum 100 characters");
        }
    }
}
