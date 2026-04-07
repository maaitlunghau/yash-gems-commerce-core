using Microsoft.Extensions.Options;
using MassTransit;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Infrastructure.Settings;
using YashGems.Commerce.Application.Contracts;
using YashGems.Commerce.Infrastructure.Persistence;
using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Worker.Workers
{
    public class GoldPriceWorker : BackgroundService
    {
        private readonly ILogger<GoldPriceWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly GoldPriceSettings _settings;
        private readonly IBus _bus;

        public GoldPriceWorker(
            ILogger<GoldPriceWorker> logger,
            IServiceProvider _serviceProvider,
            IOptions<GoldPriceSettings> settings,
            IBus bus)
        {
            _logger = logger;
            this._serviceProvider = _serviceProvider;
            _settings = settings.Value;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Gold Price Worker is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Gold Price Worker is fetching latest rate at: {time}", DateTimeOffset.Now);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var goldPriceService = scope.ServiceProvider.GetRequiredService<IGoldPriceService>();

                    try
                    {
                        decimal currentRate = await goldPriceService.GetLatestGoldPriceInVndAsync();

                        _logger.LogInformation("Successfully fetched gold rate: {rate} VND/gram", currentRate);

                        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                        dbContext.GoldPriceHistories.Add(new GoldPriceHistory
                        {
                            PricePerGram = currentRate,
                            Source = "GoldAPI.io"
                        });
                        await dbContext.SaveChangesAsync(stoppingToken);

                        await _bus.Publish<IGoldPriceUpdatedEvent>(new
                        {
                            NewGoldRate = currentRate,
                            UpdatedAt = DateTime.UtcNow
                        }, stoppingToken);

                        _logger.LogInformation("Published GoldPriceUpdatedEvent to RabbitMQ.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to fetch/publish gold price. Worker will retry in the next cycle.");
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(_settings.UpdateIntervalMinutes), stoppingToken);
            }

            _logger.LogInformation("Gold Price Worker is stopping.");
        }
    }
}
