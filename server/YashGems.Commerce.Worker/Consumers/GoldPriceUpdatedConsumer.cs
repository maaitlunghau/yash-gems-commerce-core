using MassTransit;
using Microsoft.Extensions.Logging;
using YashGems.Commerce.Application.Contracts;
using YashGems.Commerce.Domain.Repositories;
using YashGems.Commerce.Domain.Entities;

namespace YashGems.Commerce.Worker.Consumers
{
    public class GoldPriceUpdatedConsumer : IConsumer<IGoldPriceUpdatedEvent>
    {
        private readonly ILogger<GoldPriceUpdatedConsumer> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        // Giả lập tỉ giá vàng hiện tại cho công thức tính (Dùng giá lấy từ Event)
        // Trong thực tế, ProductService nên được inject vào đây để tái sử dụng logic tính toán

        public GoldPriceUpdatedConsumer(
            ILogger<GoldPriceUpdatedConsumer> logger,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<IGoldPriceUpdatedEvent> context)
        {
            var newRate = context.Message.NewGoldRate;
            _logger.LogInformation("Consumer received New Gold Rate: {rate} VND/gram. Starting bulk recalculation...", newRate);

            try
            {
                var products = await _productRepository.GetAllAsync();
                int count = 0;

                foreach (var product in products)
                {
                    product.MRP = CalculateNewMRP(product, newRate);
                    await _productRepository.Update(product);
                    count++;
                }

                await _unitOfWork.CompleteAsync();

                _logger.LogInformation("Successfully updated prices for {count} products at new gold rate.", count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during bulk price update.");
                throw;
            }
        }

        private decimal CalculateNewMRP(Product product, decimal goldRate)
        {
            decimal goldWeight = product.GoldWeight ?? 0m;
            decimal goldValue = goldWeight * goldRate;

            decimal wastageValue = (product.Wastage / 100m) * goldValue;

            decimal subTotal = goldValue +
                               product.GoldMakingCharge +
                               product.StoneMakingCharge +
                               product.OtherMakingCharge +
                               wastageValue;

            decimal taxAmount = (product.Tax / 100m) * subTotal;

            return Math.Round(subTotal + taxAmount, 2);
        }
    }
}
