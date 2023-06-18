using CryptoCurrencyQuote.API.Infrastructure;
using CryptoCurrencyQuote.Domain.Common.Settings;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Settings settings = builder.Configuration.Get<Settings>()!;

builder.Services.AddServices(settings);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCompression();

app.MapDefaultControllerRoute();

app.Run();
