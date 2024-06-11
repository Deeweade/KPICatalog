namespace KPICatalog.Domain.Dtos.Filters;

public class BonusSchemeObjectLinkFilterDto
{
    public List<int>? LinkedObjectsIds { get; set; }
    public int? LinkedObjectTypeId { get; set; }
    public int? BonusSchemeId { get; set; }
}
