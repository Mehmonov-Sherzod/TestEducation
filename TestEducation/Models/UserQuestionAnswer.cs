namespace TestEducation.Models
{
    public class UserQuestionAnswer
    {
        public int Id { get; set; }
        public int Order { get; set; }  
        public int UserQuestionId { get; set; }

        public bool IsMarked { get; set; }
        public UserQuestion UserQuestion { get; set; }
        public int AnswerId { get; set; }
        public Answer  Answer { get; set; }

    }
}
