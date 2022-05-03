using MediatR;
using SimpleFinance.StocksService.Application.Models;

namespace SimpleFinance.StocksService.Application.Queries;

public record GetStocksList(string? Exchange, string? Symbol, string? Country) : IRequest<StocksList>;
