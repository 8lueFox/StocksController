using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Queries.StockActionQueries;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries.StockActionQueryHandlers;

internal sealed class GetStockActionHandler : IRequestHandler<GetStockAction, StockActionDto?>
{
    private readonly DbSet<StockActionReadModel> _stockActions;
    public GetStockActionHandler(ReadDbContext context)
        => _stockActions = context.StockActions;

    public async Task<StockActionDto?> Handle(GetStockAction request, CancellationToken cancellationToken)
    {
        return await _stockActions
            .Where(x => x.Id == request.Id)
            .Select(x => x.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
