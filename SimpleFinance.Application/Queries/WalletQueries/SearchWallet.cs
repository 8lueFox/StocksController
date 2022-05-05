using MediatR;
using SimpleFinance.Application.Dto;

namespace SimpleFinance.Application.Queries.WalletQueries;

public record SearchWallet(string SearchPhrase) : IRequest<IEnumerable<WalletDto>>;