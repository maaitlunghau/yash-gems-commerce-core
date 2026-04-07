using YashGems.Commerce.Worker.Consumers;
using YashGems.Commerce.Infrastructure.Persistence;
using YashGems.Commerce.Infrastructure.Repositories;
using YashGems.Commerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

// Cấu hình Database cho Worker (Để nó có thể đọc ghi Product)
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySQL");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Đăng ký Repository & UnitOfWork (Copy từ Api)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<GoldPriceSettings>(builder.Configuration.GetSection("GoldPrice"));
builder.Services.AddHttpClient<IGoldPriceService, GoldPriceService>();

// Configure MassTransit for Worker
builder.Services.AddMassTransit(x =>
{
    // Đăng ký Consumer
    x.AddConsumer<GoldPriceUpdatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/");
        
        // Đăng kí Endpoint cho Consumer
        cfg.ReceiveEndpoint("gold-price-updated-queue", e =>
        {
            e.ConfigureConsumer<GoldPriceUpdatedConsumer>(context);
        });
    });
});

builder.Services.AddHostedService<GoldPriceWorker>();

var host = builder.Build();
host.Run();
