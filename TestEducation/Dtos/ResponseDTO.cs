namespace TestEducation.Dtos
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        
    }
    public class ResponseDTO<T> : ResponseDTO
    {
        public T Data { get; set; }
    }
}
