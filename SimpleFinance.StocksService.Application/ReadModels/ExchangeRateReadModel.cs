namespace SimpleFinance.StocksService.Application.ReadModels;

public class ExchangeRateReadModel
{
    public string symbol { get; set; } = string.Empty;
    public double rate { get; set; }
    public long timestamp { get; set; }
}
