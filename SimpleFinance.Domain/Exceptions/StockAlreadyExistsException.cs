namespace SimpleFinance.Domain.Exceptions;

public class StockAlreadyExistsException : AppException
{
    public StockAlreadyExistsException(Stock item) 
        : base($"Stock with name {item._name} already exists in wallet.") { }
}
