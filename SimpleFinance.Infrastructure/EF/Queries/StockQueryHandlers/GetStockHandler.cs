using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Queries.StockQueries;
using SimpleFinance.Application.Services;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries.StockQueryHandlers;

internal sealed class GetStockHandler : IRequestHandler<GetStock, StockDto?>
{
    private readonly DbSet<StockReadModel> _stocks;
    private readonly IStockService _stockService;

    public GetStockHandler(ReadDbContext context, IStockService stockService)
    {
        _stockService = stockService;
        _stocks = context.Stocks;
    }

    public async Task<StockDto?> Handle(GetStock request, CancellationToken cancellationToken)
    {
        StockDto? stock = await _stocks
            .Include(w => w.Items)
            .Where(w => w.Id == request.Id)
            .Select(w => w.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        if(stock is null)
            return null;

        var price = await _stockService.GetCurrentPrice(stock.Name);

        if (price is null)
            return null;

        stock.ActualPrice = price.Value;

        return stock;
    }
}
