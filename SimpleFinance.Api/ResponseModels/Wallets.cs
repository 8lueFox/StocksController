using SimpleFinance.Application.Dto;

namespace SimpleFinance.Api.ResponseModels;

public class Wallets
{
    public List<WalletDto> Items { get; set; } = new();
}
