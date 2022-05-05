namespace SimpleFinance.Application.Dto;

public class CryptoInfoDto
{
    public string CurrencyBase { get; set; } = string.Empty;
    public string CurrencyQuote { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;

    public List<string> AvailableExchanges { get; set; } = new();
}
