using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.UserSharedSources;

namespace TestEducation.Aplication.Service
{
    public interface IUserSharedSourcesService
    {
        Task<List<UserSharedSourcesResponce>> GetMySharedSource();
    }
}
