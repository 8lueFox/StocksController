using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleFinance.Application.Dto;
using SimpleFinance.Application.Queries.WalletQueries;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries.WalletQueryHandlers;

internal sealed class GetWalletsHandler : IRequestHandler<GetWallets, IList<WalletDto>>
{
    private readonly DbSet<WalletReadModel> _wallets;

    public GetWalletsHandler(ReadDbContext context)
        => _wallets = context.Wallets;

    public async Task<IList<WalletDto>> Handle(GetWallets request, CancellationToken cancellationToken)
    {
        return await _wallets
            .Include(w => w.Items)
            .Select(w => w.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}
