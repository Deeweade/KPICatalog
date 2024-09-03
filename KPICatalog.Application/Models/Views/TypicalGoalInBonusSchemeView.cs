using AutoMapper.Configuration.Annotations;

namespace KPICatalog.Application.Models.Views;

public class TypicalGoalInBonusSchemeView : BaseEntityView
{
    public TypicalGoalInBonusSchemeView()
    {
        BonusSchemeObjectLinks = new HashSet<BonusSchemeObjectLinkView>();
    }

    public int TypicalGoalId { get; set; }
    public int ParentBSTypicalGoalId { get; set; }
    public int PeriodId { get; set; }
    public decimal Weight { get; set; }
    public decimal Plan { get; set; }
    public int TypeKeyResultId { get; set; }
    public int? EvaluationProvider { get; set; }
    public int BonusSchemeLinkMethodId { get; set; }
    public int EvaluationMethodId { get; set; }
    public int RatingScaleId { get; set; }
    public decimal? Fact { get; set; }
    public decimal? Evaluation { get; set; }

    [Ignore]
    public string Title { get; set; }
    [Ignore]
    public int PlanningCycleId { get; set; }

    public IEnumerable<int> PeriodIds { get; set; }
    public IEnumerable<BonusSchemeObjectLinkView> BonusSchemeObjectLinks { get; set; }

    public TypicalGoalView TypicalGoal { get; set; }
    public EvaluationMethodView EvaluationMethod { get; set; }
    public BonusSchemeLinkMethodView BonusSchemeLinkMethod { get; set; }
    public List<BonusSchemeView> BonusSchemes { get; set; }
}