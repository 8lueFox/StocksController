using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.StocksService.Application.Exceptions;

public class CurrencyToNullException : AppException
{
    public CurrencyToNullException()
        : base("CurrencyTo while getting exchange rate cannot be null.")
    {
    }
}
