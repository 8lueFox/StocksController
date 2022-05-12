using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Services;

namespace SimpleFinance.Infrastructure.Services;

internal sealed class StockService : IStockService
{
    public CryptoListDto GetCryptoList(string? symbol, string? currencyQuote, string? currencyBase)
    {
        throw new NotImplementedException();
    }

    public PriceDto GetCurrentPrice(string? symbol)
    {
        throw new NotImplementedException();
    }

    public ExchangeDto GetExchange(string currencyFrom, string currencyTo)
    {
        throw new NotImplementedException();
    }

    public StocksListDto GetStockList(string? exchange, string? symbol, string? country)
    {
        throw new NotImplementedException();
    }
}
