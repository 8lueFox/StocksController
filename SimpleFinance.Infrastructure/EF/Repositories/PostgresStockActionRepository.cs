using Microsoft.EntityFrameworkCore;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;
using SimpleFinance.Domain.ValueObjects.Identificators;
using SimpleFinance.Infrastructure.EF.Contexts;

namespace SimpleFinance.Infrastructure.EF.Repositories;

internal sealed class PostgresStockActionRepository : IStockActionRepository
{
    private readonly DbSet<StockAction> _stockActions;
    private readonly WriteDbContext _writeDbContext;

    public PostgresStockActionRepository(WriteDbContext dbContext)
    {
        _stockActions = dbContext.StocksActions;
        _writeDbContext = dbContext;
    }

    public async Task<StockAction?> GetAsync(StockActionId id)
        => await _stockActions.Include("_items").SingleOrDefaultAsync(w => w.Id == id);

    public async Task UpdateAsync(StockAction wallet)
    {
        _stockActions.Update(wallet);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(StockAction wallet)
    {
        _stockActions.Update(wallet);
        await _writeDbContext.SaveChangesAsync();
    }
}
