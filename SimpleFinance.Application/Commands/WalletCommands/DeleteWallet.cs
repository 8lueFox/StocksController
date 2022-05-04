using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Domain.Repositories;

namespace SimpleFinance.Application.Commands.WalletCommands;

public record DeleteWallet(Guid WalletId) : IRequest;

internal sealed class DeleteWalletHandler : IRequestHandler<DeleteWallet>
{
    private readonly IWalletRepository _walletRepository;

    public DeleteWalletHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<Unit> Handle(DeleteWallet request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetAsync(request.WalletId);

        if (wallet is null)
            throw new WalletNotFoundException(request.WalletId);

        await _walletRepository.DeleteAsync(wallet);

        return Unit.Value;
    }
}
