namespace SimpleFinance.Domain.Exceptions;

public class EmptyIdException : AppException
{
    public EmptyIdException(string type) 
        : base($"{type} cannot be null.") { }
}
