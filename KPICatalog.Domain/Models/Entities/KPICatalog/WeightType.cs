namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class WeightType : BaseEntity
{
    public WeightType()
    {
        TypicalGoals = new HashSet<TypicalGoal>();
    }

    public string? Name { get; set; }

    public virtual ICollection<TypicalGoal> TypicalGoals { get; set; }
}
