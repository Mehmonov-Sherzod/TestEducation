using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.SharedSource;

namespace TestEducation.Aplication.Service
{
    public interface ISharedSourceService
    {
        Task<CreateSharedSourceResponseModel> CreateSharedSource(CreateSharedSource createSharedSource);

        Task<PaginationResult<SharedSourceResponse>> GetAllPageSource(PageOption model, Guid SubjectId);

        Task<string> DeleteSourse(Guid Id);
    }
}
