namespace SimpleFinance.Domain.ValueObjects.Identificators;

public class WalletId
{
    public Guid Value { get; init; }

    public WalletId(Guid value)
    {
        if (value == Guid.Empty)
            throw new EmptyIdException(this.GetType().ToString());
        Value = value;
    }

    public static implicit operator Guid(WalletId id)
        => id.Value;

    public static implicit operator WalletId(Guid id)
        => new(id);
}
