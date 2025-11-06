using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestEducation.Aplication.Models.Test;
using TestEducation.Aplication.Models.UserTest;
using TestEducation.Data;
using TestEducation.Domain.Entities;
using TestEducation.Models;

namespace TestEducation.Aplication.Service.Impl
{
    public class TestService : ITestService
    {
        private readonly AppDbContext _appDbContext;

        public TestService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<UserTestResult> StartTest(TestResponseModel testResponseModel, UserTestModel userTestModel)
        {
            throw new NotImplementedException();
        }
    }
}
