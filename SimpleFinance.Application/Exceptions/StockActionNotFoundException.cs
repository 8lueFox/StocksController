using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Application.Exceptions;

public class StockActionNotFoundException : AppException
{
    public StockActionNotFoundException(Guid id)
        : base($"Stock action with id {id} cannot be found.") { }
}