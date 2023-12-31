﻿using CryptoCurrencyQuote.Data.Cache;
using CryptoCurrencyQuote.Data.CoinMarketCapServices;
using CryptoCurrencyQuote.Domain.Common.Pipelines;
using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.Interfaces.Cache;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using CryptoCurrencyQuote.Domain.Queries.GetCryptoCurrencyQuote;
using CryptoCurrencyQuote.Domain.Services;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace CryptoCurrencyQuote.API.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, Settings settings)
    {
        Assembly domainAssembly = typeof(GetCryptoCurrencyQuotesQueryHandler).Assembly;

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(domainAssembly);

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(domainAssembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
        });

        services.AddScoped<ICoinMarketCapApiClient, CoinMarketCapApiClient>();
        services.AddScoped<ICryptoCurrencyService, CryptoCurrencyService>();
        services.AddScoped<ICacheWrapper, MemoryCacheWrapper>();

        services.AddSingleton<ISettings>(settings);

        return services;
    }
}
