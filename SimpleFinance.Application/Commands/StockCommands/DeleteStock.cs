using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Domain.Repositories;

namespace SimpleFinance.Application.Commands.StockCommands;

public record DeleteStock(Guid StockId) : IRequest;

internal sealed class DeleteStockHandler : IRequestHandler<DeleteStock>
{
    private readonly IStockRepository _stockRepository;

    public DeleteStockHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<Unit> Handle(DeleteStock request, CancellationToken cancellationToken)
    {
        var stock = await _stockRepository.GetAsync(request.StockId);

        if (stock is null)
            throw new StockNotFoundException(request.StockId);

        await _stockRepository.DeleteAsync(stock);

        return Unit.Value;
    }
}