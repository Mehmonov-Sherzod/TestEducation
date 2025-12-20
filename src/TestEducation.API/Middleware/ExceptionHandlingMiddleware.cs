using System.Text.Json;
using TestEducation.Aplication.Exceptions;
using TestEducation.Aplication.Models;
using TestEducation.Domain.Exceptions;

namespace TestEducation.API.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            logger.LogError(ex.Message);

            var code = StatusCodes.Status500InternalServerError;
            var errors = new List<string> { ex.Message };

            code = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                ResourceNotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                ForbiddenException => StatusCodes.Status403Forbidden,
                UnprocessableRequestException => StatusCodes.Status422UnprocessableEntity,
                _ => code
            };

            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = null };
            var result = JsonSerializer.Serialize(ApiResult<string>.Failure(errors), jsonOptions);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
