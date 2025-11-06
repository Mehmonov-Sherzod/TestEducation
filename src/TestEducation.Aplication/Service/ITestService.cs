using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.Test;
using TestEducation.Aplication.Models.UserTest;
using TestEducation.Domain.Entities;
using TestEducation.Models;

namespace TestEducation.Aplication.Service
{
    public interface ITestService
    {
        Task<UserTestResult> StartTest(TestResponseModel testResponseModel, UserTestModel userTestModel);
    }
}
