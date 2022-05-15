using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Services;
using SimpleFinance.Infrastructure.Services.Models;
using System.Text.Json;

namespace SimpleFinance.Infrastructure.Services;

internal sealed class StockService : IStockService
{
    private readonly string _serviceUrl;
    public StockService(string url)
    {
        _serviceUrl = url;
    }

    public CryptoListDto GetCryptoList(string? symbol, string? currencyQuote, string? currencyBase)
    {
        throw new NotImplementedException();
    }

    public async Task<PriceDto?> GetCurrentPrice(string? symbol)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_serviceUrl + $"/GetCurrentPrice?Symbol={symbol}")
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        var readModel = JsonSerializer.Deserialize<PriceReadModel>(body.ToString());
        if(readModel is null)
            return null;
        return readModel.AsDto();
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
