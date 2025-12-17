using TestEducation.Domain.Entities;

namespace TestEducation.Models;

public class UserQuestion
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int QuestionId { get; set; }       
    public Question Question { get; set; }   
    public int Order { get; set; }         
    public int TextProcessId { get; set; }
    public TestProcess TestProcess { get; set; }
    public List<UserQuestionAnswer> UserAnswers { get; set; } = new List<UserQuestionAnswer>();
}

