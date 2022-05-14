using Microsoft.AspNetCore.Mvc;
using SimpleFinance.Application.Commands.WalletCommands;
using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Queries.WalletQueries;

namespace SimpleFinance.Api.Controllers;

public class WalletController : BaseController
{
    [HttpGet]
    public ActionResult AmIAlive()
    {
        return Ok();
    }

    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<WalletDto?>> Get([FromRoute] GetWallet query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateWallet command)
    {
        await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = command }, null);
    }
}
