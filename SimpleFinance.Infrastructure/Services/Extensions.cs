using SimpleFinance.Application.Dto;
using SimpleFinance.Infrastructure.Services.Models;

namespace SimpleFinance.Infrastructure.Services;

public static class Extensions
{
    public static PriceDto AsDto(this PriceReadModel readModel)
        => new()
        {
            Currency = readModel.currency,
            Value = readModel.value
        };
}
