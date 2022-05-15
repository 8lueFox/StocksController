﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleFinance.Application.Services;
using SimpleFinance.Domain.Repositories;
using SimpleFinance.Infrastructure.EF.Contexts;
using SimpleFinance.Infrastructure.EF.Options;
using SimpleFinance.Infrastructure.EF.Repositories;
using SimpleFinance.Infrastructure.EF.Services;
using SimpleFinance.Infrastructure.Services;
using SimpleFinance.Shared.Options;

namespace SimpleFinance.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IWalletRepository, PostgresWalletRepository>();
        services.AddScoped<IStockRepository, PostgresStockRepository>();
        services.AddScoped<IStockActionRepository, PostgresStockActionRepository>();
        services.AddScoped<IWalletReadService, PostgresWalletReadService>();

        var postgresOptions = configuration.GetOptions<PostgresOptions>("Postgres");
        
        services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseNpgsql(postgresOptions.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseNpgsql(postgresOptions.ConnectionString));

        return services;
    }
}
