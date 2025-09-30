using TestEducation.Dtos;

namespace TestEducation.Service.SubjectService
{
    public interface ISubjectServise
    {
        Task<string> CreateSubject(SubjectDTO subjectDTO );

        Task<IEnumerable<SubjectDTO>> GetaAllSubjects();    

        Task<SubjectDTO> GetByIdSubject(int id);    

        Task<string> UpdateSubject(int id , SubjectDTO subjectDTO);

        Task<string> DeleteSubject(int id); 
    }
}
