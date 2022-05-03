namespace SimpleFinance.Domain.Events.WalletEvents;

public record WalletStockAdded(Wallet Wallet, Stock Stock) : IDomainEvent;