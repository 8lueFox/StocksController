namespace SimpleFinance.StocksService.Application.Models;

public class Price
{
    public string Currency { get; set; } = string.Empty;
    public double Value { get; set; }
}
