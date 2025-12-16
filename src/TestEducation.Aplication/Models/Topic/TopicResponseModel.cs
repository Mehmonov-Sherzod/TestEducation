namespace TestEducation.Aplication.Models.Topic
{
    public class TopicResponseModel
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int QuestionCount { get; set; }
    }
}
