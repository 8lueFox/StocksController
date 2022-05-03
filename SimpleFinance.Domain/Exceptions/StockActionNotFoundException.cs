namespace SimpleFinance.Domain.Exceptions;

public class StockActionNotFoundException : AppException
{
    public StockActionNotFoundException(StockActionId itemId) 
        : base($"Stock action with id {itemId} cannot be found in list of actions") { }
}
