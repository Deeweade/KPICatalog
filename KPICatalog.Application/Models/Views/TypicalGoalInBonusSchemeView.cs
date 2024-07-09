using AutoMapper.Configuration.Annotations;

namespace KPICatalog.Application.Models.Views;

public class TypicalGoalInBonusSchemeView : BaseEntityView
{
    public TypicalGoalInBonusSchemeView()
    {
        BonusSchemeObjectLinks = new HashSet<BonusSchemeObjectLinkView>();
    }
    public int? TypicalGoalId { get; set; }
    public int? ParentBSTypicalGoalId { get; set; }
    public int? PeriodId { get; set; }
    public int? Weight { get; set; }
    public int? Plan { get; set; }
    public int? TypeKeyResultId { get; set; }
    public int? EvaluationProvider { get; set; }
    public int? BonusSchemeLinkMethodId { get; set; }
    public int? EvaluationMethodId { get; set; }
    public int? RatingScaleId { get; set; }
    public int? Fact { get; set; }
    public int? Evaluation { get; set; }

    [Ignore]
    public string Title { get; set; }
    [Ignore]
    public int PlanningCycleId { get; set; }

    public IEnumerable<int> PeriodIds { get; set; }
    public IEnumerable<BonusSchemeObjectLinkView> BonusSchemeObjectLinks { get; set; }
}