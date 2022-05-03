using MediatR;
using SimpleFinance.StocksService.Application.Models;

namespace SimpleFinance.StocksService.Application.Queries;

public record GetCryptoList(string? Symbol, string? CurrencyQuote, string? CurrencyBase) : IRequest<CryptoList>;

