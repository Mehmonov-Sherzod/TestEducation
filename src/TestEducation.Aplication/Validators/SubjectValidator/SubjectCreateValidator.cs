using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Models.Subject;
using TestEducation.Data;

namespace TestEducation.Aplication.Validators.SubjectValidator
{
    public class SubjectCreateValidator : AbstractValidator<CreateSubjectModel>
    {
        private readonly AppDbContext _context;
        public SubjectCreateValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(s => s.Name)
                .MinimumLength(3).WithMessage("Subject Name should have minimum 3 characters")
                .MaximumLength(20).WithMessage("Subject Name should have maximum 20 characters")
                .MustAsync(async (name, cancellation) =>
                !await _context.Subjects.AnyAsync(s => s.Name == name))
                    .WithMessage("Subject Name must be unique");


        }
    }
}
