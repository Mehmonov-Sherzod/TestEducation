using TestEducation.Domain.Entities;

namespace TestEducation.Models;

public class UserQuestion
{
    public Guid Id { get; set; } 
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    public int Order { get; set; }
    public Guid TextProcessId { get; set; }
    public TestProcess TestProcess { get; set; }
    public List<UserQuestionAnswer> UserAnswers { get; set; }
}

