using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Application.Exceptions;

public class StockNotFoundException : AppException
{
    public StockNotFoundException(Guid id)
        : base($"Stock with id {id} cannot be found.") { }
}
