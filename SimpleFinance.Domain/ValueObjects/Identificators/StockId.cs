namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class StockId : ObjectId
{
    public StockId(Guid value) : base(value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
    }

    public static implicit operator Guid(StockId id)
        => id.Value;

    public static implicit operator StockId(Guid id)
        => new(id);
}
