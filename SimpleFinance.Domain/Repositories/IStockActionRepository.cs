namespace SimpleFinance.Domain.Repositories;

public interface IStockActionRepository
{
    Task<StockAction> GetAsync(StockActionId id);
    Task AddAsync(StockAction wallet);
    Task UpdateAsync(StockAction wallet);
    Task DeleteAsync(StockAction wallet);
}
