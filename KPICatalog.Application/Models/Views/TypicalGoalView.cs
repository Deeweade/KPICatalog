namespace KPICatalog.Application.Models.Views;

public class TypicalGoalView : BaseEntityView
{
    public TypicalGoalView()
    {
        TypicalGoalInBonusSchemes = new HashSet<TypicalGoalInBonusSchemeView>();
    }
    public string? Title { get; set; }
    public int? GoalTypeId { get; set; }
    public int? WeightTypeId { get; set; }
    public int? ParentGoalId { get; set; }
    public string? ExternalId { get; set; }

    public virtual IEnumerable<TypicalGoalInBonusSchemeView> TypicalGoalInBonusSchemes { get; set; }
}