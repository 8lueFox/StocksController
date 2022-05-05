using SimpleFinance.Domain.Consts;

namespace SimpleFinance.Application.Dto;

public class StockActionDto
{
    public Guid Id { get; set; }
    public float Quantity { get; set; }
    public float Price { get; set; }
    public DateTime ActionTime { get; set; }
    public StockActionType ActionType { get; set; }
}
