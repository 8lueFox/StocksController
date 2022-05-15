using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleFinance.Application.Services;
using SimpleFinance.Infrastructure.EF;
using SimpleFinance.Infrastructure.EF.Options;
using SimpleFinance.Infrastructure.Services;
using SimpleFinance.Shared.Options;
using System.Reflection;

namespace SimpleFinance.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);

        var servicesOptions = configuration.GetOptions<ServicesOptions>("Services");

        services.AddScoped<IStockService, StockService>(s => new StockService(servicesOptions.StockServiceUrl));

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
