namespace SimpleFinance.StocksService.Application.ReadModels;

public class CryptoInfoReadModel
{
    public string currency_base { get; set; } = string.Empty;
    public string currency_quote { get; set; } = string.Empty;
    public string symbol { get; set; } = string.Empty;
    public List<string> available_exchanges { get; set; } = new();
}
