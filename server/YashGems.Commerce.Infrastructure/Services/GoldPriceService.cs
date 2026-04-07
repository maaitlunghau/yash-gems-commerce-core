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

                if (root.TryGetProperty("price_gram_24k", out var priceElement))
                {
                    return priceElement.GetDecimal();
                }

                if (root.TryGetProperty("price", out var ouncePriceElement))
                {
                    decimal ouncePrice = ouncePriceElement.GetDecimal();
                    return Math.Round(ouncePrice / 31.1034768m, 2);
                }

                throw new Exception("Could not find gold price in API response.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Fetching gold price failed: {ex.Message}");
            }
        }
    }
}
