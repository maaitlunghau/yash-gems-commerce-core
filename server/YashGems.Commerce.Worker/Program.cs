using YashGems.Commerce.Infrastructure.Services;
using YashGems.Commerce.Infrastructure.Settings;
using YashGems.Commerce.Worker.Workers;
using YashGems.Commerce.Application.Interfaces;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<GoldPriceSettings>(builder.Configuration.GetSection("GoldPrice"));

builder.Services.AddHttpClient<IGoldPriceService, GoldPriceService>();

// Configure MassTransit for Worker
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/");
    });
});

builder.Services.AddHostedService<GoldPriceWorker>();

var host = builder.Build();
host.Run();
