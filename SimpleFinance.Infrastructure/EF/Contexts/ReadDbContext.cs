﻿using Microsoft.EntityFrameworkCore;
using SimpleFinance.Infrastructure.EF.Config;
using SimpleFinance.Infrastructure.EF.Consts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<WalletReadModel> Wallets { get; set; }
    public DbSet<StockReadModel> Stocks { get; set; }
    public DbSet<StockActionReadModel> StockActions { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DatabaseNames.StocksSchema);

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<WalletReadModel>(configuration);
        modelBuilder.ApplyConfiguration<StockReadModel>(configuration);
        modelBuilder.ApplyConfiguration<StockActionReadModel>(configuration);
    }
}
