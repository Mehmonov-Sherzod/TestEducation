using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Models.SharedSource
{
    public class CreateSharedSource
    {
        public string Description { get; set; }

        public IFormFile? Image { get; set; }

        public Guid SubjectId { get; set; }
    }
    public class CreateSharedSourceResponseModel : BaseResponseModel;

}
