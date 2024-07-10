namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class BonusSchemeLinkMethod : BaseEntity
{
    public BonusSchemeLinkMethod()
    {
        TypicalGoalInBonusSchemes = new HashSet<TypicalGoalInBonusScheme>();
    }

    public string Name { get; set; }

    public virtual ICollection<TypicalGoalInBonusScheme> TypicalGoalInBonusSchemes { get; set; }
}