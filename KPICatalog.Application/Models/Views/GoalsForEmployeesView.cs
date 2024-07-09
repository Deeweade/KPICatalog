using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Application.Models.Views;

public class GoalsForEmployeesRequestView
{
    public IEnumerable<TypicalGoalInBonusSchemeView> Goals { get; internal set; }
    public IEnumerable<int> EmployeesIds { get; internal set; }
}
