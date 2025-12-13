using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;


namespace TestEducation.Service.SubjectService
{
    public interface ISubjectServise
    {
        Task<CreateSubjectResponseModel> CreateSubject(CreateSubjectModel subjectDTO );
        Task<PaginationResult<SubjectResponsModel>> CreateSubjectPage(PageOption model, string lang);
        Task<SubjectResponsModel> GetByIdSubject(int id, string lang);
        Task<UpdateSubjectResponseModel> UpdateSubject(int Id, UpdateSubjectModel subjectDTO);
        Task<string> DeleteSubject(int id);
        Task<List<SubjectResponsModel>> GetAllSubjects(string lang);
    }
}
