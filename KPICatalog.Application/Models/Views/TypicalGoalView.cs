namespace KPICatalog.Application.Models.Views;

public class TypicalGoalView : BaseEntityView
{
    public TypicalGoalView()
    {
        TypicalGoalInBonusSchemes = new HashSet<TypicalGoalInBonusSchemeView>();
    }
    public string? Title { get; set; }
    public int? PlanningCycleId { get; set; }
    public int? WeightTypeId { get; set; }
    public int? ParentGoalId { get; set; }
    public string? ExternalId { get; set; }

    public TypicalGoalInBonusSchemeView? TypicalGoalInBonusSchemeView { get; set; }
    public ICollection<TypicalGoalInBonusSchemeView> TypicalGoalInBonusSchemes { get; set; }
}