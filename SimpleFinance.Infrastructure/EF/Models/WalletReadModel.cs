namespace SimpleFinance.Infrastructure.EF.Models;

internal class WalletReadModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<StockReadModel> Items { get; set; } = new List<StockReadModel>();
}
