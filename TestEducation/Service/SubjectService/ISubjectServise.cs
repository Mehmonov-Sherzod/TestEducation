using TestEducation.Dtos;

namespace TestEducation.Service.SubjectService
{
    public interface ISubjectServise
    {
        Task<ResponseDTO> CreateSubject(SubjectDTO subjectDTO );

        Task<ResponseDTO<ICollection<SubjectDTO>>> GetaAllSubjects();    

        Task<ResponseDTO<SubjectDTO>> GetByIdSubject(int id);    

        Task<ResponseDTO<SubjectDTO>> UpdateSubject(int id , SubjectDTO subjectDTO);

        Task<ResponseDTO> DeleteSubject(int id); 
    }
}
