namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class BonusSchemeObjectLink : BaseEntity
{
    public int BonusSchemeId { get; set; }
    public int LinkedObjectId { get; set; }
    public int LinkedObjectTypeId { get; set; }

    public virtual LinkedObjectType? LinkedObjectType { get; set; }
    public virtual BonusScheme? BonusScheme { get; set; }
}