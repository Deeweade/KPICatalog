namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class PlanningCycle : BaseEntity
{
    public PlanningCycle()
    {
        BonusSchemes = new HashSet<BonusScheme>();
        TypicalGoals = new HashSet<TypicalGoal>();
    }

    public string Name { get; set; }

    public virtual ICollection<TypicalGoal> TypicalGoals { get; set; }
    public virtual ICollection<BonusScheme> BonusSchemes { get; set; }

}