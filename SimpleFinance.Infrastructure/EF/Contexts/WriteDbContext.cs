using Microsoft.EntityFrameworkCore;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Infrastructure.EF.Config;
using SimpleFinance.Infrastructure.EF.Consts;

namespace SimpleFinance.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<StockAction> StocksActions { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options)
        : base(options) { }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DatabaseNames.StocksSchema);

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Wallet>(configuration);
        modelBuilder.ApplyConfiguration<Stock>(configuration);
        modelBuilder.ApplyConfiguration<StockAction>(configuration);
    }
}
