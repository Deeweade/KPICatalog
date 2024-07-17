namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class EvaluationMethod : BaseEntity
{
    public EvaluationMethod()
    {
        TypicalGoalInBonusSchemes = new HashSet<TypicalGoalInBonusScheme>();   
    }

    public string Name { get; set; }

    public virtual ICollection<TypicalGoalInBonusScheme> TypicalGoalInBonusSchemes { get; set; }
}
