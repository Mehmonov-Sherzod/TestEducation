namespace TestEducation.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<UserTestResult> userTestResult { get; set; }
    }
}
