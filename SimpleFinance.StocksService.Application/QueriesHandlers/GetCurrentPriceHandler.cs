using MediatR;
using SimpleFinance.StocksService.Application.Communicators;
using SimpleFinance.StocksService.Application.Exceptions;
using SimpleFinance.StocksService.Application.Models;
using SimpleFinance.StocksService.Application.Queries;
using SimpleFinance.StocksService.Application.ReadModels;
using System.Text.Json;

namespace SimpleFinance.StocksService.Application.QueriesHandlers;

public class GetCurrentPriceHandler : IRequestHandler<GetCurrentPrice, Price>
{
    private readonly IApiCommunicator _apiCommunicator;

    public GetCurrentPriceHandler(IApiCommunicator apiCommunicator)
        => _apiCommunicator = apiCommunicator;

    public async Task<Price> Handle(GetCurrentPrice request, CancellationToken cancellationToken)
    {
        if (request.Symbol == string.Empty)
            throw new SymbolNullException();

        var parameters = $"symbol={request.Symbol}&";

        var response = await _apiCommunicator.SendGetRequest($"price?{parameters}format=json");
        var readModel = JsonSerializer.Deserialize<PriceReadModel>(response.ToString());

        if (readModel == null)
            throw new StocksListEmptyException();

        readModel.price = readModel.price.Replace('.', ',');

        var model =  readModel!.AsModel();
        model.Currency = request.Symbol;
        return model;
    }
}
