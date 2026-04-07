namespace YashGems.Commerce.Application.Interfaces
{
    public interface IGoldPriceService
    {
        Task<decimal> GetLatestGoldPriceInVndAsync();
        Task<decimal> GetLatestExchangeRateAsync();
    }
}
