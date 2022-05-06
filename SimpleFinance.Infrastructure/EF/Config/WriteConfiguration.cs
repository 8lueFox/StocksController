using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.ValueObjects.Identificators;
using SimpleFinance.Domain.ValueObjects.Names;
using SimpleFinance.Infrastructure.EF.Consts;

namespace SimpleFinance.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Wallet>, IEntityTypeConfiguration<Stock>, IEntityTypeConfiguration<StockAction>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasKey(x => x.Id);

        var walletNameConverter = new ValueConverter<WalletName, string>(w => w.Value, w => new WalletName(w));

        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, id => new WalletId(id));

        builder
            .Property(typeof(WalletName), "_name")
            .HasConversion(walletNameConverter)
            .HasColumnName("Name");

        builder
            .HasMany(typeof(Stock), "_items");

        builder.ToTable(DatabaseNames.WalletTableName);
    }

    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(x => x.Id);

        var stockNameConverter = new ValueConverter<StockName, string>(w => w.Value, w => new StockName(w));
        var exchangeNameConverter = new ValueConverter<ExchangeName, string>(w => w.Value, w => new ExchangeName(w));

        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, id => new StockId(id));

        builder
            .Property(typeof(StockName), "_name")
            .HasConversion(stockNameConverter)
            .HasColumnName("Name");

        builder
            .Property(typeof(ExchangeName), "_exchange")
            .HasConversion(exchangeNameConverter)
            .HasColumnName("Exchange");

        builder
            .HasMany(typeof(StockAction), "_items");

        builder.ToTable(DatabaseNames.StocksTableName);
    }

    public void Configure(EntityTypeBuilder<StockAction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable(DatabaseNames.StocksActionsTableName);
    }
}
