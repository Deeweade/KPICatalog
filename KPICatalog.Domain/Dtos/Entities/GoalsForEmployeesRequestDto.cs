namespace KPICatalog.Domain.Dtos.Entities;

public class GoalsForEmployeesRequestDto
{
    public IEnumerable<TypicalGoalInBonusSchemeDto> Goals { get; set; }
    public IEnumerable<int> EmployeesIds { get; set; }
}