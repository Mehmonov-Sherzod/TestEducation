using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.SharedSource;

namespace TestEducation.Aplication.Service
{
    public interface ISharedSourceService
    {
        Task<CreateSharedSourceResponseModel> CreateSharedSource(CreateSharedSource createSharedSource);
    }
}
