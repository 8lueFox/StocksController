namespace SimpleFinance.Domain.Entities;

public class Wallet : AggregateRoot<WalletId>
{
    public WalletName _name;

    private readonly LinkedList<Stock> _items;

    public Wallet()
    {
    }

    public Wallet(WalletId walletId, WalletName walletName)
    {
        Id = walletId;
        _name = walletName;
        _items = new();
    }

    public Wallet(WalletId walletId, WalletName walletName, LinkedList<Stock> items)
        :this(walletId, walletName)
    {
        _items = items;
    }

    public void AddItem(Stock item)
    {
        var alreadyExists = _items.Any(i => i.Id == item.Id);

        if (alreadyExists)
            throw new StockAlreadyExistsException(item);

        _items.AddLast(item);
        AddEvent(new WalletStockAdded(this, item));
    }

    public void AddItems(IEnumerable<Stock> items)
    {
        foreach (var item in items)
            AddItem(item);
    }

    public void RemoveItem()
    {
        throw new NotImplementedException();
    }
}
