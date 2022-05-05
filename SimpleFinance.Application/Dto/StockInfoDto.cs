namespace SimpleFinance.Application.Dto;

public class StockInfoDto
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string Exchange { get; set; } = string.Empty;
    public string MicCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
