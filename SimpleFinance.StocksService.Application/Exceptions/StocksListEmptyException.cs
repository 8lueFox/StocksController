using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.StocksService.Application.Exceptions;

public class StocksListEmptyException : AppException
{
    public StocksListEmptyException() 
        : base("Cannot get a stocks list. Please try again later.")
    {
    }
}
