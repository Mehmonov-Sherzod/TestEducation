using Microsoft.AspNetCore.Mvc;

namespace TestEducation.Dtos
{
    public class ResponseDTO : IActionResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            JsonResult result = new JsonResult(this)
            {
                StatusCode = this.StatusCode,
            };

            await result.ExecuteResultAsync(context);
        }
    }
    public class ResponseDTO<T> : ResponseDTO
    {
        public T? Data { get; set; }
    }
}
