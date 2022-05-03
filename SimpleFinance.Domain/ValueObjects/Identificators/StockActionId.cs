namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class StockActionId : ObjectId
{
    public StockActionId(Guid value) : base(value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
    }
}