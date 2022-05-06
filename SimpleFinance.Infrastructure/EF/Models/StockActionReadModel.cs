using SimpleFinance.Domain.Consts;

namespace SimpleFinance.Infrastructure.EF.Models;

internal class StockActionReadModel
{
    public Guid Id { get; set; }
    public float Quantity { get; set; }
    public float Price { get; set; }
    public DateTime ActionTime { get; set; }
    public StockActionType ActionType { get; set; }

    public StockReadModel Stock { get; set; }
}
