namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class BonusScheme : HistoryEntity
{
    public BonusScheme()
    {
        BonusSchemeObjectLinks = new HashSet<BonusSchemeObjectLink>();
    }
    
    public string Title { get; set; }
    public string CostCenter { get; set; }
    public bool IsDefaulBonusScheme { get; set; }
    public int ExternalId { get; set; }
    public int PlanningCycleId { get; set; }

    public virtual PlanningCycle PlanningCycle{ get; set; }

    public virtual ICollection<BonusSchemeObjectLink> BonusSchemeObjectLinks { get; set; }
}
