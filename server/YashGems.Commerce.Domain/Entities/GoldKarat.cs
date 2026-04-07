using YashGems.Commerce.Domain.Common;

namespace YashGems.Commerce.Domain.Entities;

public class GoldKarat : BaseEntity
{
    public int Karat { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
