namespace TestEducation.Aplication.Exceptions;

[Serializable]
public class ForbiddenException(string message) : Exception(message);

