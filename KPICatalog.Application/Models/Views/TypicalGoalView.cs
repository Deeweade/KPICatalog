namespace KPICatalog.Application.Models.Views;

public class TypicalGoalView : BaseView
{
    public TypicalGoalView()
    {
        TypicalGoalsInBonusSchemes = new HashSet<TypicalGoalInBonusSchemeView>();
        BonusSchemes = new HashSet<BonusSchemeView>();
    }
    public string Title { get; set; }
    public int PlanningCycleId { get; set; }
    public int WeightTypeId { get; set; }
    public int ParentGoalId { get; set; }
    public string ExternalId { get; set; }

    public TypicalGoalInBonusSchemeView TypicalGoalInBonusScheme { get; set; }
    public IEnumerable<TypicalGoalInBonusSchemeView> TypicalGoalsInBonusSchemes { get; set; }
    public IEnumerable<BonusSchemeView> BonusSchemes { get; set; }
}