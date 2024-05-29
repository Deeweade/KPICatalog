namespace KPICatalog.Application.Models.Entities;

public class BonusSchemeView : HistoryEntityView
{
    public string? Title { get; set; }
    public string? CostCenter { get; set; }
    public bool IsDefaulBonusScheme { get; set; }
    public int? ExternalId { get; set; }
    public int? PlanningCycleId { get; set; }
}
