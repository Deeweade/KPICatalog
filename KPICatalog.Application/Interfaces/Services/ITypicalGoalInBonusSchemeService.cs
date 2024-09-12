
using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface ITypicalGoalInBonusSchemeService
{
    Task<IEnumerable<TypicalGoalInBonusSchemeView>> GetByTypicalGoalId(int goalId);
    Task<GoalsForEmployeesRequestView> GetByBonusSchemeId(int bonusSchemeId, bool includeEmployees);
    Task<TypicalGoalInBonusSchemeView> Create(TypicalGoalInBonusSchemeView view);
    Task BulkCreate(ICollection<int> bonusSchemesIds, ICollection<TypicalGoalView> typicalGoals);
    Task BulkUpdate(ICollection<int> entitiesIds, TypicalGoalInBonusSchemeView typicalGoalInBS);
    Task BulkEvaluate(List<BulkEvaluateGoalsView> view);
}
