namespace KPICatalog.Domain.Dtos.Filters;

public class BonusSchemeObjectLinkQueryDto
{
    public bool? IsActive { get; set; }
    public int? BonusSchemeId { get; set; }
    public int? LinkedObjectTypeId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? PeriodDateStart { get; set; }
    public DateTime? PeriodDateEnd { get; set; }
    public List<int> BonusSchemeIds { get; set; }
    public List<int> LinkedObjectsIds { get; set; }
}
