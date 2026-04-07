namespace YashGems.Commerce.Domain.Entities;

public class Certification
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
