using Microsoft.EntityFrameworkCore;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;
using SimpleFinance.Domain.ValueObjects.Identificators;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Repositories;

internal sealed class PostgresWalletRepository : IWalletRepository
{
    private readonly DbSet<Wallet> _wallets;
    private readonly WriteDbContext _writeDbContext;
    private readonly ReadDbContext _readDbContext;

    public PostgresWalletRepository(WriteDbContext dbContext, ReadDbContext readDbContext)
    {
        _wallets = dbContext.Wallets;
        _writeDbContext = dbContext;
        _readDbContext = readDbContext;
    }

    public async Task<Wallet?> GetWithItemsAsync(WalletId id)
        => await _wallets.Include("_items").SingleOrDefaultAsync(w => w.Id == id.Value);

    public async Task<Wallet?> GetAsync(WalletId id)
        => await _wallets.SingleOrDefaultAsync(w => w.Id == id.Value);

    public async Task AddAsync(Wallet wallet)
    {
        await _wallets.AddAsync(wallet);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        _wallets.Update(wallet);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Wallet wallet)
    {
        _wallets.Remove(wallet);
        await _writeDbContext.SaveChangesAsync();
    }
}
