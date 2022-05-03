using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.StocksService.Application.Exceptions;

public class CryptoListEmptyException : AppException
{
    public CryptoListEmptyException() 
        : base("Cannot get a stocks list. Please try again later.")
    {
    }
}
