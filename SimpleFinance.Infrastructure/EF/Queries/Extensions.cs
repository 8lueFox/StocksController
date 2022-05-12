using SimpleFinance.Application.Dto;
using SimpleFinance.Infrastructure.EF.Models;

namespace SimpleFinance.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static StockActionDto AsDto(this StockActionReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            ActionTime = readModel.ActionTime,
            ActionType = readModel.ActionType,
            Price = readModel.Price,
            Quantity = readModel.Quantity
        };

    public static StockDto AsDto(this StockReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Exchange = readModel.Exchange,
            Name = readModel.Name,
            Items = readModel.Items.Select(x => new StockActionDto
            {
                ActionTime = x.ActionTime,
                ActionType = x.ActionType,
                Id = x.Id,
                Price = x.Price,
                Quantity = x.Quantity
            })
        };

    public static WalletDto AsDto(this WalletReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Items = readModel.Items.Select(x => new StockDto
            {
                Id = x.Id,
                Exchange = x.Exchange,
                Name = x.Name
            })
        };
}
