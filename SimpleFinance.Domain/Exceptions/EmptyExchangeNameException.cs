namespace SimpleFinance.Domain.Exceptions;

public class EmptyExchangeNameException : AppException
{
    public EmptyExchangeNameException() 
        : base("Exchange name cannot be empty.") { }
}
