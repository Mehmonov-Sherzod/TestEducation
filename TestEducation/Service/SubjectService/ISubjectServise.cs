using TestEducation.Dtos;

namespace TestEducation.Service.SubjectService
{
    public interface ISubjectServise
    {
        Task<string> CreateSubject(SubjectDto subjectDto);

        Task<IEnumerable<SubjectDto>> GetaAllSubjects();    

        Task<SubjectDto> GetByIdSubject(int id);    

        Task<string> UpdateSubject(int id , SubjectDto subjectDto);

        Task<string> DeleteSubject(int id); 
    }
}
