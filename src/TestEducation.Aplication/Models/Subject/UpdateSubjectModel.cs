namespace TestEducation.Aplication.Models.Subject
{
    public  class UpdateSubjectModel 
    {
        public string SubjectNmae { get; set; }

        public List<UpdateSubjectTranslateModel> UpdateSubjectTranslateModels { get; set; }
    }
    public class UpdateSubjectResponseModel
    {
        public int Id { get; set; }
    }
}
