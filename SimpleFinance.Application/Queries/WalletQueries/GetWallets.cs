using MediatR;
using SimpleFinance.Application.Dto;

namespace SimpleFinance.Application.Queries.WalletQueries;

public record GetWallets() : IRequest<IList<WalletDto>>;