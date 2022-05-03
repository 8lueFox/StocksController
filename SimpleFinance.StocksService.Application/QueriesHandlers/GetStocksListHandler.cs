using MediatR;
using SimpleFinance.StocksService.Application.Communicators;
using SimpleFinance.StocksService.Application.Exceptions;
using SimpleFinance.StocksService.Application.Models;
using SimpleFinance.StocksService.Application.Queries;
using SimpleFinance.StocksService.Application.ReadModels;
using System.Text.Json;

namespace SimpleFinance.StocksService.Application.QueriesHandlers;

internal class GetStocksListHandler : IRequestHandler<GetStocksList, StocksList>
{
    private readonly IApiCommunicator _apiCommunicator;

    public GetStocksListHandler(IApiCommunicator apiCommunicator)
        => _apiCommunicator = apiCommunicator;

    public async Task<StocksList> Handle(GetStocksList request, CancellationToken cancellationToken)
    {
        var parameters = string.Empty;
        parameters += request.Exchange != null ? $"exchange={request.Exchange}&" : "";
        parameters += request.Country != null ? $"country={request.Country}&" : "";
        parameters += request.Symbol != null ?  $"symbol={request.Symbol}&" : "";

        var response = await _apiCommunicator.SendGetRequest($"stocks?{parameters}format=json");
        var readModel = JsonSerializer.Deserialize<StocksListReadModel>(response.ToString());

        if (readModel == null)
            throw new StocksListEmptyException();

        return readModel!.AsModel();
    }
}