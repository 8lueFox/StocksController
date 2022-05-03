namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class StockId : ObjectId
{
    public StockId(Guid value) : base(value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
    }
}
