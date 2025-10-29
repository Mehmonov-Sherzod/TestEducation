using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TestEducation.Aplication.Models.Answer;

namespace TestEducation.Aplication.Validators.AnswerValidator
{
    public class AnswerUpdateValidator : AbstractValidator<UpdateAnswerModel>
    {
        public AnswerUpdateValidator()
        {
            RuleFor(a => a.Text).MinimumLength(1).WithMessage("Answer text must contain at least 1 character");
            RuleFor(a => a.Text).MaximumLength(100).WithMessage("Answer text must not exceed 100 characters");
        }
    }
}
