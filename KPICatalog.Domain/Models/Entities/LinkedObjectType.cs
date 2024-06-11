namespace KPICatalog.Domain.Models.Entities;

public class LinkedObjectType : BaseEntity
{
    public LinkedObjectType()
    {
        BonusSchemeObjectLinks = new HashSet<BonusSchemeObjectLink>();
    }

    public string? Name { get; set; }

    public virtual ICollection<BonusSchemeObjectLink> BonusSchemeObjectLinks { get; set; }
}
