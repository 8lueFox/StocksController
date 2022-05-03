namespace SimpleFinance.StocksService.Application.Models;

public class ExchangeRate
{
    public string ExchangeFrom { get; set; } = string.Empty;
    public string ExchangeTo { get; set; } = string.Empty;
    public string Symbol { get => $"{ExchangeFrom}/{ExchangeTo}"; }
    public double Rate { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}
