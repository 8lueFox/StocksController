using SimpleFinance.StocksService.Application.Models;

namespace SimpleFinance.StocksService.Application.ReadModels;

internal static class Extensions
{
    public static StocksList AsModel(this StocksListReadModel readModel)
        => new()
        {
            Stocks = readModel.data.Select(x => new StockInfo
            {
                Currency = x.currency,
                Exchange = x.exchange,
                MicCode = x.mic_code,
                Name = x.name,
                Symbol = x.symbol,
                Type = x.type,
                Country = x.country
            }).ToList()
        };

    public static CryptoList AsModel(this CryptoListReadModel readModel)
        => new()
        {
            Cryptos = readModel.data.Select(x => new CryptoInfo
            {
                AvailableExchanges = x.available_exchanges,
                CurrencyBase = x.currency_base,
                CurrencyQuote = x.currency_quote,
                Symbol = x.symbol
            }).ToList()
        };

    public static ExchangeRate AsModel(this ExchangeRateReadModel readModel)
        => new()
        {
            Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(readModel.timestamp),
            Rate = readModel.rate,
            ExchangeFrom = readModel.symbol.Split('/').First(),
            ExchangeTo = readModel.symbol.Split('/').Last()
        };

    public static Price AsModel(this PriceReadModel readModel)
        => new()
        {
            Value = double.Parse(readModel.price)
        };
}
