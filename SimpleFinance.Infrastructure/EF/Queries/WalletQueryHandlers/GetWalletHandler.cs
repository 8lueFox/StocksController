using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Queries.WalletQueries;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries.WalletQueryHandlers;

internal sealed class GetWalletHandler : IRequestHandler<GetWallet, WalletDto?>
{
    private readonly DbSet<WalletReadModel> _wallets;

    public GetWalletHandler(ReadDbContext context)
        => _wallets = context.Wallets;


    public async Task<WalletDto?> Handle(GetWallet request, CancellationToken cancellationToken)
    {
        return await _wallets
            .Include(w => w.Items)
            .Where(w => w.Id == request.Id)
            .Select(w => w.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
