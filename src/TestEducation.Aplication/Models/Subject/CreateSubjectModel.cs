namespace TestEducation.Aplication.Models.Subject;

public class CreateSubjectModel
{
    public string Name { get; set; }

    public List<CreateSubjectTranslateModel> SubjectTranslates { get; set; }

}

public class CreateSubjectResponseModel
{
    public int Id { get; set; }
}
