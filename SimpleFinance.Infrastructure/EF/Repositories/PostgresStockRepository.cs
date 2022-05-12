using Microsoft.EntityFrameworkCore;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;
using SimpleFinance.Domain.ValueObjects.Identificators;
using SimpleFinance.Infrastructure.EF.Contexts;

namespace SimpleFinance.Infrastructure.EF.Repositories;

internal sealed class PostgresStockRepository : IStockRepository
{
    private readonly DbSet<Stock> _stocks;
    private readonly WriteDbContext _writeDbContext;

    public PostgresStockRepository(WriteDbContext dbContext)
    {
        _stocks = dbContext.Stocks;
        _writeDbContext = dbContext;
    }

    public async Task<Stock?> GetAsync(StockId id)
        => await _stocks.Include("_items").SingleOrDefaultAsync(w => w.Id == id);

    public async Task UpdateAsync(Stock wallet)
    {
        _stocks.Update(wallet);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Stock wallet)
    {
        _stocks.Remove(wallet);
        await _writeDbContext.SaveChangesAsync();
    }
}
