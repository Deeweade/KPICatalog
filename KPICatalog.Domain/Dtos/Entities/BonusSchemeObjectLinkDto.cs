namespace KPICatalog.Domain.Dtos.Entities;

public class BonusSchemeObjectLinkDto : HistoryEntityDto
{
    public int BonusSchemeId { get; set; }
    public int LinkedObjectId { get; set; }
    public int LinkedObjectTypeId { get; set; }
    public int? LinkPercent { get; set; }

    public List<int> LinkedObjectsIds { get; set; }
}
