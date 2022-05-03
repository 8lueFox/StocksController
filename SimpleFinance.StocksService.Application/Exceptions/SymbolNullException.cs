using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.StocksService.Application.Exceptions;

public class SymbolNullException : AppException
{
    public SymbolNullException()
        : base("Symbol while getting symbol price cannot be null.")
    {
    }
}
