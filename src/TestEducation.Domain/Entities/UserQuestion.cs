using TestEducation.Domain.Entities;

namespace TestEducation.Models;

public class UserQuestion
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
    public string QuestionText { get; set; }
    public string SubjectName { get; set; }
    public Guid TestProcessId { get; set; }
    public TestProcess TestProcess { get; set; }
    public User User { get; set; }
    public List<UserQuestionAnswer> UserQuestionAnswers { get; set; }
}

