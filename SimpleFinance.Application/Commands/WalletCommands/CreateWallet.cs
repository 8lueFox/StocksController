using MediatR;
using SimpleFinance.Application.Exceptions;
using SimpleFinance.Application.Services;
using SimpleFinance.Domain.Entities;
using SimpleFinance.Domain.Repositories;

namespace SimpleFinance.Application.Commands.WalletCommands;

public record CreateWallet(string WalletName) : IRequest;

internal sealed class CreateWalletHandler : IRequestHandler<CreateWallet>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IWalletReadService _walletReadService;

    public CreateWalletHandler(IWalletRepository walletRepository, IWalletReadService walletReadService)
    {
        _walletRepository = walletRepository;
        _walletReadService = walletReadService;
    }

    public async Task<Unit> Handle(CreateWallet request, CancellationToken cancellationToken)
    {
        var (id, name) = (Guid.NewGuid(), request.WalletName);

        if (await _walletReadService.ExistsByNameAsync(name))
            throw new WalletAlreadyExistsException(name);

        Wallet wallet = new(id, name);

        await _walletRepository.AddAsync(wallet);

        return Unit.Value;
    }
}
