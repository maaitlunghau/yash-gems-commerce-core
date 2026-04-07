namespace YashGems.Commerce.Application.Contracts
{
    public interface IGoldPriceUpdatedEvent
    {
        decimal NewGoldRate { get; }
        DateTime UpdatedAt { get; }
    }
}
