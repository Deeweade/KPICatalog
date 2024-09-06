namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class RatingScale : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<RatingScaleValue> Values { get; set; }
    public virtual ICollection<TypicalGoalInBonusScheme> Goals { get; set; }
}
