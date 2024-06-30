namespace KPICatalog.Domain.Dtos.Entities;

public class TypicalGoalInBonusSchemeDto : BaseEntityDto
{
    public int? TypicalGoalId { get; set; }
    public int? ParentBSTypicalGoalId { get; set; }
    public int? PeriodId { get; set; }
    public int? Weight { get; set; }
    public int? Plan { get; set; }
    public int? TypeKeyResultID { get; set; }
    public int? EvaluationProvider { get; set; }
    public int? BonusSchemeLinkMethodId { get; set; }
    public int? EvaluationMethodId { get; set; }
    public int? RatingScaleId { get; set; }
    public int? Fact { get; set; }
    public int? Evaluation { get; set; }

    public PeriodDto Period { get; set; }
}