using MediatR;
using SimpleFinance.Application.Dto;

namespace SimpleFinance.Application.Queries.StockActionQueries;

public record GetStockAction(Guid Id) : IRequest<StockActionDto>;