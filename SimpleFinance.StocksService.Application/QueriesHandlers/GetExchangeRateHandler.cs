using MediatR;
using SimpleFinance.StocksService.Application.Communicators;
using SimpleFinance.StocksService.Application.Exceptions;
using SimpleFinance.StocksService.Application.Models;
using SimpleFinance.StocksService.Application.Queries;
using SimpleFinance.StocksService.Application.ReadModels;
using System.Text.Json;

namespace SimpleFinance.StocksService.Application.QueriesHandlers;

public class GetExchangeRateHandler : IRequestHandler<GetExchangeRate, ExchangeRate>
{
    private readonly IApiCommunicator _apiCommunicator;

    public GetExchangeRateHandler(IApiCommunicator apiCommunicator)
        => _apiCommunicator = apiCommunicator;

    public async Task<ExchangeRate> Handle(GetExchangeRate request, CancellationToken cancellationToken)
    {
        if (request.CurrencyFrom == string.Empty)
            throw new CurrencyFromNullException();
        if (request.CurrencyTo == string.Empty)
            throw new CurrencyToNullException();

        var parameters = $"symbol={request.CurrencyFrom}/{request.CurrencyTo}&";

        var response = await _apiCommunicator.SendGetRequest($"exchange_rate?{parameters}format=json");
        var readModel = JsonSerializer.Deserialize<ExchangeRateReadModel>(response.ToString());

        if (readModel == null)
            throw new StocksListEmptyException();

        return readModel!.AsModel();
    }
}
