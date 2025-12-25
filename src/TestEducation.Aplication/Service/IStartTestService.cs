using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.StartTestMixed;
using TestEducation.Aplication.Models.TestProcsess;

namespace TestEducation.Aplication.Service
{
    public interface IStartTestService
    {
        Task<TestProcessResponce> StartTestMixed30(StartTestMixedModels StartTestMixedModels);
    }
}
