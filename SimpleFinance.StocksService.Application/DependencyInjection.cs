using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleFinance.StocksService.Application.Communicators;
using System.Reflection;

namespace SimpleFinance.StocksService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<IApiCommunicator, TwelveDataApiCommunicator>();

        return services;
    }
}
