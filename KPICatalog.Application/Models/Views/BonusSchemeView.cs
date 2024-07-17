using AutoMapper.Configuration.Annotations;

namespace KPICatalog.Application.Models.Views;

public class BonusSchemeView : HistoryEntityView
{
    public BonusSchemeView()
    {
        Employees = new HashSet<EmployeeView>();
    }

    public string Title { get; set; }
    public string CostCenter { get; set; }
    public bool IsDefaulBonusScheme { get; set; }
    public int? ExternalId { get; set; }
    public int? PlanningCycleId { get; set; }

    [Ignore]
    public IEnumerable<EmployeeView> Employees { get; set; }
    public IEnumerable<TypicalGoalInBonusSchemeView> TypicalGoalInBonusSchemes { get; set; }
}
