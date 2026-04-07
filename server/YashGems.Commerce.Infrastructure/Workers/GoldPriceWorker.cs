using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MassTransit;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Infrastructure.Settings;
using YashGems.Commerce.Application.Contracts;

namespace YashGems.Commerce.Infrastructure.Workers
{
    public class GoldPriceWorker : BackgroundService
    {
        private readonly ILogger<GoldPriceWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly GoldPriceSettings _settings;
        private readonly IPublishEndpoint _publishEndpoint;

        public GoldPriceWorker(
            ILogger<GoldPriceWorker> logger,
            IServiceProvider serviceProvider,
            IOptions<GoldPriceSettings> settings,
            IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _settings = settings.Value;
            _publishEndpoint = publishEndpoint;
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

                        await _publishEndpoint.Publish<IGoldPriceUpdatedEvent>(new
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

                // 3. Nghỉ ngơi theo cấu hình (ví dụ 15 phút)
                await Task.Delay(TimeSpan.FromMinutes(_settings.UpdateIntervalMinutes), stoppingToken);
            }

            _logger.LogInformation("Gold Price Worker is stopping.");
        }
    }
}
