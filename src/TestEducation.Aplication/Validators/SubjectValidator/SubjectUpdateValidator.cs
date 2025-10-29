using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Data;

namespace TestEducation.Aplication.Validators.SubjectValidator
{
    public class SubjectUpdateValidator : AbstractValidator<UpdateSubjectModel>
    {
        private readonly AppDbContext _context;
        public SubjectUpdateValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(s => s.SubjectNmae)
                .MinimumLength(3).WithMessage("Subject Name should have minimum 3 characters")
                .MaximumLength(20).WithMessage("Subject Name should have maximum 20 characters");
        }
    }
}
