using MediatR;
using SimpleFinance.StocksService.Application.Models;

namespace SimpleFinance.StocksService.Application.Queries;

public record GetExchangeRate(string CurrencyFrom, string CurrencyTo) : IRequest<ExchangeRate>;
