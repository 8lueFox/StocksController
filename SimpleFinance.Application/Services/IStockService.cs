using SimpleFinance.Application.Dto;

namespace SimpleFinance.Application.Services;

public interface IStockService
{
    public PriceDto GetCurrentPrice(string symbol);

    public StocksListDto GetStockList(string? exchange, string? symbol, string? country);

    public CryptoListDto GetCryptoList(string? symbol, string? currencyQuote, string? currencyBase);

    public ExchangeDto GetExchange(string currencyFrom, string currencyTo);
}
