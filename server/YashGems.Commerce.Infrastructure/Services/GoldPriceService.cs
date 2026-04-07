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
                decimal liveUsdToVndRate = await GetLiveExchangeRateAsync();

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("x-access-token", _settings.GoldApiKey);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.GetAsync(_settings.GoldApiUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(content);
                var root = doc.RootElement;

                decimal usdPricePerGram = 0;

                if (root.TryGetProperty("price_gram_24k", out var priceElement))
                {
                    usdPricePerGram = priceElement.GetDecimal();
                }
                else if (root.TryGetProperty("price", out var ouncePriceElement))
                {
                    decimal ouncePrice = ouncePriceElement.GetDecimal();
                    usdPricePerGram = ouncePrice / 31.1034768m;
                }
                else
                {
                    throw new Exception($"Price keys not found. JSON Response: {content}");
                }

                return Math.Round(usdPricePerGram * liveUsdToVndRate, 2);
            }
            catch (Exception ex)
            {
                throw new Exception($"Fetching gold price failed: {ex.Message}");
            }
        }

        private async Task<decimal> GetLiveExchangeRateAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_settings.ExchangeRateApiUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(content);

                if (doc.RootElement.TryGetProperty("rates", out var ratesElement) &&
                    ratesElement.TryGetProperty("VND", out var vndRateElement))
                {
                    decimal rate = vndRateElement.GetDecimal();
                    return rate;
                }

                return _settings.UsdToVndRate;
            }
            catch
            {
                return _settings.UsdToVndRate;
            }
        }
    }
}
