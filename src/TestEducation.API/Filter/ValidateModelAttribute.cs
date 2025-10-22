using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestEducation.Aplication.Models;

namespace TestEducation.API.Filter
{
    public class ValidateModelAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                IEnumerable<string> errors = context.ModelState.Values
                    .SelectMany(modelState => modelState.Errors)
                    .Select(modelErrors => modelErrors.ErrorMessage);

                context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errors));
            }
            await next();
        }
        
    }
}
