using MediatR;
using SimpleFinance.Application.Dto;

namespace SimpleFinance.Application.Queries.WalletQueries;

public record GetWallet(Guid Id) : IRequest<WalletDto?>;