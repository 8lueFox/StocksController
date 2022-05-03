namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class WalletId : ObjectId
{
    public WalletId(Guid value) : base(value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
    }
}
