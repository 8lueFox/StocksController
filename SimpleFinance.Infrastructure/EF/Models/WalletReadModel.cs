namespace SimpleFinance.Infrastructure.EF.Models;

internal class WalletReadModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<StockReadModel> Items { get; set; }
}
