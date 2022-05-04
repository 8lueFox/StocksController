namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class StockActionId : ObjectId
{
    public StockActionId(Guid value) : base(value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
    }

    public static implicit operator Guid(StockActionId id)
        => id.Value;

    public static implicit operator StockActionId(Guid id)
        => new(id);
}