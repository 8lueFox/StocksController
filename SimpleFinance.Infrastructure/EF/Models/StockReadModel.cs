namespace SimpleFinance.Infrastructure.EF.Models;

internal class StockReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Exchange { get; set; } = string.Empty;
    public ICollection<StockActionReadModel> Items { get; set; } = new List<StockActionReadModel>();

    public WalletReadModel Wallet { get; set; } = new();
}
