namespace TestEducation.Aplication.Models.Topic
{
    public class TopicResponseModel
    {
        public Guid Id { get; set; }
        public string TopicName { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int QuestionCount { get; set; }
    }
}
