namespace SimpleFinance.Domain.ValueObjects.Names;

public record ExchangeName
{
    public string Value { get; }

    public ExchangeName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyExchangeNameException();
        Value = value;
    }

    public static implicit operator string(ExchangeName name)
        => name.Value;

    public static implicit operator ExchangeName(string name)
        => new(name);
}
