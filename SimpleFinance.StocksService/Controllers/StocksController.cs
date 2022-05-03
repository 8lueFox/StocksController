using Microsoft.AspNetCore.Mvc;
using SimpleFinance.StocksService.Application.Models;
using SimpleFinance.StocksService.Application.Queries;

namespace SimpleFinance.StocksService.Api.Controllers;

public class StocksController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<StocksList>> GetStocks([FromQuery] GetStocksList query)
    {
        var result = await Mediator.Send(query);

        result.Stocks = result.Stocks.Take(100).ToList();

        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<CryptoList>> GetCrypto([FromQuery] GetCryptoList query)
    {
        var result = await Mediator.Send(query);

        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<ExchangeRate>> GetExchangeRate([FromQuery] GetExchangeRate query)
    {
        var result = await Mediator.Send(query);

        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<Price>> GetCurrentPrice([FromQuery] GetCurrentPrice query)
    {
        var result = await Mediator.Send(query);

        return OkOrNotFound(result);
    }
}
