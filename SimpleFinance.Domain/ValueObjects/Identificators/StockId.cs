namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class StockId
{
    public Guid Value { get; init; }

    public StockId(Guid value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
        Value = value;
    }

    public static implicit operator Guid(StockId id)
        => id.Value;

    public static implicit operator StockId(Guid id)
        => new(id);
}
