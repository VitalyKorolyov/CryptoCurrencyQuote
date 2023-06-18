using CryptoCurrencyQuote.API.Infrastructure;
using CryptoCurrencyQuote.Domain.Common.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Settings settings = builder.Configuration.Get<Settings>()!;

builder.Services.AddServices(settings);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();
