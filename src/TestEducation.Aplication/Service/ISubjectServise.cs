using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Subject;


namespace TestEducation.Service.SubjectService
{
    public interface ISubjectServise
    {
        Task<CreateSubjectResponseModel> CreateSubject(CreateSubjectModel subjectDTO );
        Task<List<SubjectResponsModel>> GetaAllSubjects();
        Task<PaginationResult<SubjectResponsModel>> CreateSubjectPage(SubjectPageModel subjectDTO);
        Task<SubjectResponsModel> GetByIdSubject(int id);    
        Task<UpdateSubjectResponseModel> UpdateSubject(int Id, UpdateSubjectModel subjectDTO);
        Task<string> DeleteSubject(int id); 
    }
}
