using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IGoalsRepository
{
    Task BulkUpdate(GoalsForEmployeesRequestDto data);
    Task BulkDelete(GoalsForEmployeesRequestDto data);
}
