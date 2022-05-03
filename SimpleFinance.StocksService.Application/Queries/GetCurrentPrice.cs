using MediatR;
using SimpleFinance.StocksService.Application.Models;

namespace SimpleFinance.StocksService.Application.Queries;

public record GetCurrentPrice(string Symbol) : IRequest<Price>;
