using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;
using YashGems.Commerce.Application.Interfaces;
using YashGems.Commerce.Infrastructure.Settings;

namespace YashGems.Commerce.Infrastructure.Services
{
    public class GoldPriceService : IGoldPriceService
    {
        private readonly HttpClient _httpClient;
        private readonly GoldPriceSettings _settings;

        public GoldPriceService(HttpClient httpClient, IOptions<GoldPriceSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<decimal> GetLatestGoldPriceInVndAsync()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("x-access-token", _settings.GoldApiKey);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetAsync(_settings.GoldApiUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(content);
                var root = doc.RootElement;

                decimal usdPricePerGram = 0;
                const decimal usdToVndRate = 25450m; // Tỉ giá USD/VND hiện tại (có thể cấu hình sau)

                // 1. Thử lấy giá gram 24k trực tiếp (USD)
                if (root.TryGetProperty("price_gram_24k", out var priceElement))
                {
                    usdPricePerGram = priceElement.GetDecimal();
                }
                // 2. Nếu không có, lấy giá Ounce (price) rồi chia cho 31.1035
                else if (root.TryGetProperty("price", out var ouncePriceElement))
                {
                    decimal ouncePrice = ouncePriceElement.GetDecimal();
                    usdPricePerGram = ouncePrice / 31.1034768m;
                }
                else
                {
                    throw new Exception($"Price keys not found. JSON Response: {content}");
                }

                // Chuyển đổi sang VND
                return Math.Round(usdPricePerGram * usdToVndRate, 2);
            }
            catch (Exception ex)
            {
                throw new Exception($"Fetching gold price failed: {ex.Message}");
            }
        }
    }
}
