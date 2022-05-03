namespace SimpleFinance.Domain.Events.StockEvents;

public record StockActionRemoved(Stock Stock, StockAction StockAction) : IDomainEvent;