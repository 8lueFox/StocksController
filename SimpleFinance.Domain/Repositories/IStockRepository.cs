namespace SimpleFinance.Domain.Repositories;

public interface IStockRepository
{
    Task<Stock?> GetAsync(StockId id);
    Task UpdateAsync(Stock wallet);
    Task DeleteAsync(Stock wallet);
}
