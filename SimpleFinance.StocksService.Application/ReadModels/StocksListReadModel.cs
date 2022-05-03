namespace SimpleFinance.StocksService.Application.ReadModels;

internal class StocksListReadModel
{
    public List<StockInfoReadModel> data { get; set; } = new();
}
