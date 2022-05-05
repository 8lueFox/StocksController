using MediatR;
using SimpleFinance.Application.Dto;

namespace SimpleFinance.Application.Queries.StockQueries;

public record GetStock(Guid Id) : IRequest<StockDto>;