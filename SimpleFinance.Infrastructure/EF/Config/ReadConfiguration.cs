using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleFinance.Infrastructure.EF.Consts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<WalletReadModel>, IEntityTypeConfiguration<StockReadModel>, IEntityTypeConfiguration<StockActionReadModel>
{
    public void Configure(EntityTypeBuilder<WalletReadModel> builder)
    {
        builder.ToTable(DatabaseNames.WalletTableName);
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.Wallet);
    }

    public void Configure(EntityTypeBuilder<StockReadModel> builder)
    {
        builder.Property(x => x.Exchange).IsRequired(false);

        builder.ToTable(DatabaseNames.StocksTableName);
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.Stock);
    }

    public void Configure(EntityTypeBuilder<StockActionReadModel> builder)
    {
        builder.ToTable(DatabaseNames.StocksActionsTableName);
    }
}
