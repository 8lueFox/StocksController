using SimpleFinance.Shared.Abstractions.Exceptions;

namespace SimpleFinance.Application.Exceptions;

public class WalletNotFoundException : AppException
{
    public WalletNotFoundException(Guid id) 
        : base($"Wallet with id {id} cannot be found.") { }
}
