namespace SimpleFinance.Application.Dto;

public class WalletDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<StockDto> Items { get; set; } = new LinkedList<StockDto>();
}
