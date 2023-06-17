using CryptoCurrencyQuote.Data.CoinMarketCapServices;
using CryptoCurrencyQuote.Domain.Common.Pipelines;
using CryptoCurrencyQuote.Domain.Common.Settings;
using CryptoCurrencyQuote.Domain.CryptoCurrencyRates.Queries.GetCryptoCurrencyRates;
using CryptoCurrencyQuote.Domain.Interfaces.Clients.CoinMarketCap;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace CryptoCurrencyQuote.API.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services,
        Settings settings)
    {
        Assembly domainAssembly = typeof(GetCryptoCurrencyRatesQueryHandler).Assembly;

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(domainAssembly);

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(domainAssembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
        });

        services.AddScoped<ICoinMarketCapClient, CoinMarketCapClient>();
        services.AddSingleton<ISettings>(settings);

        return services;
    }
}
