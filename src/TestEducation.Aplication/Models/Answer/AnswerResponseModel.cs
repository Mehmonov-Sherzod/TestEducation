namespace TestEducation.Aplication.Models.Answer
{
    public class AnswerResponseModel
    {
        public string AnswerText { get; set; }

        public List<AnswerTranslateResponseModel> Translate { get; set; }
    }
}
