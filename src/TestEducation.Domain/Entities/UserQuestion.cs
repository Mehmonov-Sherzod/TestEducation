namespace TestEducation.Models;

public class UserQuestion
{
    public int UserId { get; set; }
    public int Order {  get; set; }
    public User User { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }  
    public DateTime AnsweredAt { get; set; } 
    public List<UserQuestionAnswer> UserAnswers { get; set; } 
}

