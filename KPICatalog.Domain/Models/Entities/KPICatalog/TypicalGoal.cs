namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class TypicalGoal : BaseEntity
{
    public TypicalGoal()
    {
        TypicalGoalInBonusSchemes = new HashSet<TypicalGoalInBonusScheme>();
    }
    
    public string? Title { get; set; }
    public int? GoalTypeId { get; set; }
    public int? WeightTypeId { get; set; }
    public int? ParentGoalId { get; set; }
    public string? ExternalId { get; set; }
    
    public virtual ICollection<TypicalGoalInBonusScheme> TypicalGoalInBonusSchemes { get; set; }
}