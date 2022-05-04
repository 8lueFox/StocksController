using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Domain.Consts;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;

namespace SimpleFinance.Application.Commands.StockCommands;

public record AddStockActionToStock(Guid StockId, float Quantity, float Price, DateTime ActionTime, StockActionType ActionType) : IRequest;

internal sealed class AddStockActionToStockHandler : IRequestHandler<AddStockActionToStock>
{
    private readonly IStockRepository _stockRepository;

    public AddStockActionToStockHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<Unit> Handle(AddStockActionToStock request, CancellationToken cancellationToken)
    {
        var stock = await _stockRepository.GetAsync(request.StockId);

        if (stock is null)
            throw new StockNotFoundException(request.StockId);

        var stockAction = new StockAction(request.Quantity, request.Price, request.ActionTime, request.ActionType);

        stock.AddItem(stockAction);

        await _stockRepository.UpdateAsync(stock);

        return Unit.Value;
    }
}