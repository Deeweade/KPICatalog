namespace KPICatalog.Application.Models.Views;

public class BonusSchemeObjectLinkView : HistoryEntityView
{
    public BonusSchemeObjectLinkView()
    {
        LinkedObjectsIds = new List<int>();
    }

    public int BonusSchemeId { get; set; }
    public int LinkedObjectId { get; set; }
    public int LinkedObjectTypeId { get; set; }
    public int? LinkPercent { get; set; }

    public List<int> LinkedObjectsIds { get; set; }

    public BonusSchemeView BonusScheme { get; set; }
}
