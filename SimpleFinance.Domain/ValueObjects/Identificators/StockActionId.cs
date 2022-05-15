namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class StockActionId
{
    public Guid Value { get; init; }

    public StockActionId(Guid value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
        Value = value;
    }

    public static implicit operator Guid(StockActionId id)
        => id.Value;

    public static implicit operator StockActionId(Guid id)
        => new(id);
}