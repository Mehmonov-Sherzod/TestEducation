using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.SharedSource;
using TestEducation.Aplication.Models.Users;
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
            string? urlFile = null;

            if (createSharedSource.File != null && createSharedSource.File.Length > 0)
            {
  
                if (createSharedSource.File.Length > 52428800)
                {
                    throw new Exception("Fayl hajmi 50 MB dan oshmasligi kerak");
                }

                var extension = Path.GetExtension(createSharedSource.File.FileName);

                var allowedExtensions = new[] { ".pdf", ".docx", ".doc", ".txt", ".epub", ".jpg", ".png" };
                if (!allowedExtensions.Contains(extension.ToLower()))
                {
                    throw new Exception("Fayl formati qo'llab-quvvatlanmaydi");
                }

                var objectName = $"{Guid.NewGuid()}{extension}";
                using var mystream = createSharedSource.File.OpenReadStream();

                var bucketName = extension.ToLower() switch
                {
                    ".pdf" or ".docx" or ".doc" or ".txt" or ".epub" => "shared-books",
                    ".jpg" or ".png" or ".jpeg" => "shared-images",
                    _ => "shared-files"
                };

                urlFile = await _fileStoreageService.UploadFileAsync(
                    bucketName,
                    objectName,
                    mystream,
                    createSharedSource.File.ContentType
                );
            }

            var source = new SharedSource()
            {
                Path = urlFile,
                SubjectId = createSharedSource.SubjectId,
                Price = createSharedSource.Price,
                Description = createSharedSource.Description,
            };

            _appDbContext.SharedSources.Add(source);
            await _appDbContext.SaveChangesAsync();

            return new CreateSharedSourceResponseModel
            {
                Id = source.Id,
            };

        }

        public async Task<string> DeleteSourse(Guid Id)
        {
            var source = await _appDbContext.SharedSources.FirstOrDefaultAsync(x => x.Id == Id);

            if (source == null)
                throw new NotFoundException("subject topilmadi.");

            _appDbContext.SharedSources.Remove(source);
            await _appDbContext.SaveChangesAsync();

            return "Subject o'chirildi";
        }

        public async Task<PaginationResult<SharedSourceResponse>> GetAllPageSource(PageOption model , Guid SubjectId)
        {

            var query = _appDbContext.SharedSources
                .Where(x => x.SubjectId == SubjectId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(s => s.Description.Contains(model.Search));
            }
            Console.WriteLine(query.ToQueryString());
            List<SharedSourceResponse> SharedSource = await query
                .Skip(model.PageSize * (model.PageNumber - 1))
                .Take(model.PageSize)
                .Select(x => new SharedSourceResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    Image = x.Path,
                    Price = x.Price
                }).ToListAsync();

            int total = _appDbContext.SharedSources.Count();

            return new PaginationResult<SharedSourceResponse>
            {
                Values = SharedSource,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                TotalCount = total
            };
        }
    }
}
