namespace SimpleFinance.Domain.Events.StockEvents;

public record StockActionAdded(Stock Stock, StockAction StockAction) : IDomainEvent;