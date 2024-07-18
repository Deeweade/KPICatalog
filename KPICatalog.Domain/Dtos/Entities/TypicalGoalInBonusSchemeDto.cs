namespace KPICatalog.Domain.Dtos.Entities;

public class TypicalGoalInBonusSchemeDto : BaseEntityDto
{
    public int TypicalGoalId { get; set; }
    public int ParentBSTypicalGoalId { get; set; }
    public int PeriodId { get; set; }
    public decimal Weight { get; set; }
    public decimal Plan { get; set; }
    public int TypeKeyResultId { get; set; }
    public int EvaluationProvider { get; set; }
    public int BonusSchemeLinkMethodId { get; set; }
    public int EvaluationMethodId { get; set; }
    public int RatingScaleId { get; set; }
    public decimal? Fact { get; set; }
    public decimal? Evaluation { get; set; }

    public PeriodDto Period { get; set; }
    public EvaluationMethodDto EvaluationMethod { get; set; }
    public BonusSchemeLinkMethodDto BonusSchemeLinkMethod { get; set; }
    public TypicalGoalDto TypicalGoal { get; set; }
}