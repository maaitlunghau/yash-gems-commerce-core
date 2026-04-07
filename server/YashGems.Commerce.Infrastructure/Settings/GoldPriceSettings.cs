namespace YashGems.Commerce.Infrastructure.Settings
{
    public class GoldPriceSettings
    {
        public string SjcUrl { get; set; } = string.Empty;
        public string GoldApiUrl { get; set; } = string.Empty;
        public string GoldApiKey { get; set; } = string.Empty;
        public int UpdateIntervalMinutes { get; set; }
        public decimal UsdToVndRate { get; set; } = 25450m;
        public string ExchangeRateApiUrl { get; set; } = string.Empty;
    }
}
