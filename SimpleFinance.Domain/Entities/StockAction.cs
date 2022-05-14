namespace SimpleFinance.Domain.Entities;

public class StockAction : AggregateRoot<Guid>
{
    public float Quantity { get; set; }
    public float Price { get; set; }
    public DateTime ActionTime { get; set; }
    public StockActionType ActionType { get; set; }

    public StockAction(float quantity, float price, DateTime actionTime, StockActionType actionType)
    {
        Id = Guid.NewGuid();
        ActionType = actionType;
        Quantity = quantity;
        Price = price;
        ActionTime = actionTime;
    }
}
