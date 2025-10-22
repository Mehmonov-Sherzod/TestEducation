using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TestEducation.Aplication.Models.Question;

namespace TestEducation.Aplication.Validators.QuestionValidator
{
    public  class QuestionCreateValidator : AbstractValidator<CreateQuestionModel>
    {
        public QuestionCreateValidator()
        {
            RuleFor(q => q.QuestionText)
                .MinimumLength(5)
                     .WithMessage("Question title should have minimum 5 characters")
                .MaximumLength(100)
                     .WithMessage("Question title should have maximum 100 characters");

        }

    }
}
