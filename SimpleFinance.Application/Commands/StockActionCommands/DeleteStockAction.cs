using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Domain.Repositories;

namespace SimpleFinance.Application.Commands.StockCommands;

public record DeleteStockAction(Guid StockActionId) : IRequest;

internal sealed class DeleteStockActionkHandler : IRequestHandler<DeleteStockAction>
{
    private readonly IStockActionRepository _stockActionRepository;

    public DeleteStockActionkHandler(IStockActionRepository stockActionRepository)
    {
        _stockActionRepository = stockActionRepository;
    }

    public async Task<Unit> Handle(DeleteStockAction request, CancellationToken cancellationToken)
    {
        var stockAction = await _stockActionRepository.GetAsync(request.StockActionId);

        if (stockAction is null)
            throw new StockActionNotFoundException(request.StockActionId);

        await _stockActionRepository.DeleteAsync(stockAction);

        return Unit.Value;
    }
}