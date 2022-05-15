namespace SimpleFinance.Domain.Repositories;

public interface IWalletRepository
{
    Task<Wallet?> GetWithItemsAsync(WalletId id);
    Task<Wallet?> GetAsync(WalletId id);
    Task AddAsync(Wallet wallet);
    Task UpdateAsync(Wallet wallet);
    Task DeleteAsync(Wallet wallet);
}
