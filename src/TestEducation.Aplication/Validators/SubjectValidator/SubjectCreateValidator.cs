using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TestEducation.Aplication.Models.Subject;

namespace TestEducation.Aplication.Validators.SubjectValidator
{
    public class SubjectCreateValidator : AbstractValidator<CreateSubjectModel>
    {
        public SubjectCreateValidator()
        {
            RuleFor(s => s.Name)
                .MinimumLength(3)
                    .WithMessage("Subject Name should have minimum 3 characters")
                .MaximumLength(20)
                    .WithMessage("Subject Name should have maximum 20 characters");
        }
    }
}
