namespace SimpleFinance.Shared.Abstractions.Domain;

public class ObjectId
{
    public Guid Value { get; init; }

    public ObjectId(Guid value)
    {
        Value = value;
    }

    public static implicit operator Guid(ObjectId id)
        => id.Value;

    public static implicit operator ObjectId(Guid id)
        => new(id);
}
