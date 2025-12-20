using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;


namespace TestEducation.Service.SubjectService
{
    public interface ISubjectServise
    {
        Task<CreateSubjectResponseModel> CreateSubject(CreateSubjectModel subjectDTO );
        Task<PaginationResult<SubjectResponsModel>> CreateSubjectPage(PageOption model, string lang);
        Task<SubjectResponsModel> GetByIdSubject(Guid id, string lang);
        Task<UpdateSubjectResponseModel> UpdateSubject(Guid Id, UpdateSubjectModel subjectDTO);
        Task<string> DeleteSubject(Guid id);
        Task<List<SubjectResponsModel>> GetAllSubjects(string lang);
    }
}
