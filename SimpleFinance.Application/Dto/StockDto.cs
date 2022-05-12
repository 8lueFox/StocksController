namespace SimpleFinance.Application.Dto;

public class StockDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Exchange { get; set; } = string.Empty;
    public double ActualPrice { get; set; }
    public IEnumerable<StockActionDto> Items { get; set; } = new LinkedList<StockActionDto>();
}
