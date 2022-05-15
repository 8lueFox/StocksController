using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;

namespace SimpleFinance.Application.Commands.WalletCommands;

public record AddStockToWallet(Guid WalletId, string StockName, string ExchangeName) : IRequest;

internal sealed class AddStockToWalletHandler : IRequestHandler<AddStockToWallet>
{
    private readonly IWalletRepository _walletRepository;

    public AddStockToWalletHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<Unit> Handle(AddStockToWallet request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetWithItemsAsync(request.WalletId);

        if (wallet is null)
            throw new WalletNotFoundException(request.WalletId);

        var stock = new Stock(request.StockName, request.ExchangeName);
        wallet.AddItem(stock);

        await _walletRepository.UpdateAsync(wallet);

        return Unit.Value;
    }
}
