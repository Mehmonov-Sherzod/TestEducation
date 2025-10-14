namespace TestEducation.Aplication.Exceptions;

[Serializable]
public class BadRequestException(string message) : Exception(message);

