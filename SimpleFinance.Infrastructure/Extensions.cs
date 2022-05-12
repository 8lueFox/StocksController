using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleFinance.Application.Services;
using SimpleFinance.Infrastructure.EF;
using SimpleFinance.Infrastructure.Services;
using System.Reflection;

namespace SimpleFinance.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);

        services.AddScoped<IStockService, StockService>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
