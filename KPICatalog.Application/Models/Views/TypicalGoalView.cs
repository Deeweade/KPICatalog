namespace KPICatalog.Application.Models.Views;

public class TypicalGoalView : BaseEntityView
{
    public TypicalGoalView()
    {
        TypicalGoalInBonusSchemes = new HashSet<TypicalGoalInBonusSchemeView>();
        BonusScheme = new HashSet<BonusSchemeView>();
    }
    public string? Title { get; set; }
    public int? PlanningCycleId { get; set; }
    public int? WeightTypeId { get; set; }
    public int? ParentGoalId { get; set; }
    public string? ExternalId { get; set; }

    public TypicalGoalInBonusSchemeView? TypicalGoalInBonusScheme { get; set; }
    public IEnumerable<TypicalGoalInBonusSchemeView?> TypicalGoalInBonusSchemes { get; set; }
    public IEnumerable<BonusSchemeView?> BonusScheme { get; set; }
}