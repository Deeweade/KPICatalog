using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Application.Models.Views;

public class GoalsForEmployeesRequestView
{
    public IEnumerable<TypicalGoalInBonusSchemeDto> Goals { get; internal set; }
    public IEnumerable<BonusSchemeObjectLinkDto> EmployeesIds { get; internal set; }
}
