namespace KPICatalog.Domain.Dtos.Entities;

public class BonusSchemeObjectLinkDto : BaseEntityDto
{
    public int? BonusSchemeId { get; set; }
    public int? LinkedObjectId { get; set; }
    public int? LinkedObjectTypeId { get; set; }
}
