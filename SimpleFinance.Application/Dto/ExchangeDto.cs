namespace SimpleFinance.Application.Dto;

public class ExchangeDto
{
    public string Symbol { get; set; } = string.Empty;
    public double Rate { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}
