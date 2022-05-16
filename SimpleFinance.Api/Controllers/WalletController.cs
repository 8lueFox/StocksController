using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Api.ResponseModels;
using SimpleFinance.Application.Commands.WalletCommands;
using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Queries.StockQueries;
using SimpleFinance.Application.Queries.WalletQueries;

namespace SimpleFinance.Api.Controllers;

public class WalletController : BaseController
{
    [HttpGet]
    public ActionResult AmIAlive()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<Wallets>> GetWallets([FromRoute] GetWallets query)
    {
        var response = await Mediator.Send(query);
        return new Wallets
        {
            Items = response.ToList()
        };
    }

    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<WalletDto?>> GetWallet([FromRoute] GetWallet query)
    {
        var response = await Mediator.Send(query);
        return response;
    }
    
    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<StockDto?>> GetStock([FromRoute] GetStock query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWallet([FromBody] CreateWallet command)
    {
        await Mediator.Send(command);

        return CreatedAtAction(nameof(GetWallet), new { id = command.Id }, null);
    }

    [HttpPost] 
    public async Task<IActionResult> AddStockToWallet([FromBody] AddStockToWallet command)
    {
        await Mediator.Send(command);

        return CreatedAtAction(nameof(GetWallet), new { id = command.WalletId }, null);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveWallet([FromBody] DeleteWallet command)
    {
        await Mediator.Send(command);

        return CreatedAtAction(nameof(GetWallet), new { id = command.WalletId }, null);
    }

}
