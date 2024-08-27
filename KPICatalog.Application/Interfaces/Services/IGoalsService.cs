using KPICatalog.Application.Models.Enums;

namespace KPICatalog.Application.Interfaces.Services;

public interface IGoalsService
{
    Task SyncGoals(SyncMethods syncMethod, List<int> employeeIds = null, 
        List<int> goalIds = null, List<int> bonusSchemeIds = null);
}
