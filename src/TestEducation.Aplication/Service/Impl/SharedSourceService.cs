using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models.SharedSource;
using TestEducation.Data;
using TestEducation.Domain.Entities;
using TestEducation.Service.FileStoreageService;

namespace TestEducation.Aplication.Service.Impl
{
    public class SharedSourceService : ISharedSourceService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileStoreageService _fileStoreageService;

        public SharedSourceService(AppDbContext appDbContext, IFileStoreageService fileStoreageService)
        {
            _appDbContext = appDbContext;
            _fileStoreageService = fileStoreageService;
        }
        public async Task<CreateSharedSourceResponseModel> CreateSharedSource(CreateSharedSource createSharedSource)
        {
            string? urlImage = null;

            if (createSharedSource.Image != null && createSharedSource.Image.Length > 0)
            {
                var extension = Path.GetExtension(createSharedSource.Image.FileName);
                var objectName = $"{Guid.NewGuid()}{extension}";
                using var mystream = createSharedSource.Image.OpenReadStream();
                urlImage = await _fileStoreageService.UploadFileAsync(
                    "questions-image",
                    objectName,
                    mystream,
                    createSharedSource.Image.ContentType
                );
            }

            var source = new SharedSource()
            {
                Path = urlImage,
                SubjectId = createSharedSource.SubjectId,
                Description = createSharedSource.Description,
            };

            return new CreateSharedSourceResponseModel
            {
                Id = source.Id,
            };

        }
    }
}
