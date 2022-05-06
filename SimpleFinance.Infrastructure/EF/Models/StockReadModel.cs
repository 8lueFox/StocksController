namespace SimpleFinance.Infrastructure.EF.Models;

internal class StockReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Exchange { get; set; }
    public ICollection<StockActionReadModel> Items { get; set; }

    public WalletReadModel Wallet { get; set; }
}
