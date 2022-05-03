using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.StocksService.Application.Exceptions;

public class CurrencyFromNullException : AppException
{
    public CurrencyFromNullException()
        : base("CurrencyFrom while getting exchange rate cannot be null.")
    {
    }
}
