namespace KPICatalog.Domain.Models.Entities;

public class BonusSchemeObjectLink : BaseEntity
{
    public int? BonusSchemeId { get; set; }
    public int? LinkedObjectId { get; set; }
    public int? LinkedObjectType { get; set; }

    public virtual BonusScheme? BonusScheme { get; set; }
}