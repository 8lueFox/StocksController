namespace SimpleFinance.Domain.Entities;

public class Stock : AggregateRoot<StockId>
{
    public StockName _name;

    public ExchangeName _exchange;

    private readonly LinkedList<StockAction> _items;

    public Stock(StockId stockId, StockName name, ExchangeName exchange)
    {
        Id = stockId;
        _name = name;
        _exchange = exchange;
        _items = new();
    }

    public Stock(StockId stockId, StockName name, ExchangeName exchange, LinkedList<StockAction> items)
        : this(stockId, name, exchange)
    {
        _items = items;
    }

    public void AddItem(StockAction item)
    {
        _items.AddLast(item);
        AddEvent(new StockActionAdded(this, item));
    }

    public void AddItems(IEnumerable<StockAction> items)
    {
        foreach (var item in items)
            AddItem(item);
    }

    public void RemoveItem(StockActionId itemId)
    {
        var item = GetItem(itemId);
        _items.Remove(item);
        AddEvent(new StockActionRemoved(this, item));
    }

    private StockAction GetItem(StockActionId itemId)
    {
        var item = _items.SingleOrDefault(x => x.Id == itemId);

        if (item is null)
            throw new StockActionNotFoundException(itemId);

        return item;
    }
}
