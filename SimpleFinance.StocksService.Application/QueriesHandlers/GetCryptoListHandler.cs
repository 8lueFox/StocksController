using MediatR;
using SimpleFinance.StocksService.Application.Communicators;
using SimpleFinance.StocksService.Application.Exceptions;
using SimpleFinance.StocksService.Application.Models;
using SimpleFinance.StocksService.Application.Queries;
using SimpleFinance.StocksService.Application.ReadModels;
using System.Text.Json;

namespace SimpleFinance.StocksService.Application.QueriesHandlers;

public class GetCryptoListHandler : IRequestHandler<GetCryptoList, CryptoList>
{
    private readonly IApiCommunicator _apiCommunicator;

    public GetCryptoListHandler(IApiCommunicator apiCommunicator)
        => _apiCommunicator = apiCommunicator;

    public async Task<CryptoList> Handle(GetCryptoList request, CancellationToken cancellationToken)
    {
        var parameters = string.Empty;
        parameters += request.CurrencyQuote ?? $"currency_quote={request.CurrencyQuote}&";
        parameters += request.CurrencyBase ?? $"currency_base={request.CurrencyBase}&";
        parameters += request.Symbol ?? $"symbol={request.Symbol}&";

        var response = await _apiCommunicator.SendGetRequest($"cryptocurrencies?{parameters}format=json");
        var readModel = JsonSerializer.Deserialize<CryptoListReadModel>(response.ToString());

        if (readModel == null)
            throw new CryptoListEmptyException();

        return readModel!.AsModel();
    }
}
