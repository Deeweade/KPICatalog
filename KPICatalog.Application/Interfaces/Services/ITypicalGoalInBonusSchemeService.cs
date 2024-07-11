
using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface ITypicalGoalInBonusSchemeService
{
    Task<IEnumerable<TypicalGoalInBonusSchemeView>> GetByTypicalGoalId(int goalId);
    Task<GoalsForEmployeesRequestView> GetGoalsToSync(int bonusSchemeId);
    Task BulkCreate(ICollection<int> bonusSchemesIds, ICollection<TypicalGoalView> typicalGoals);
    Task BulkUpdate(ICollection<int> entitiesIds, TypicalGoalInBonusSchemeView typicalGoalInBS);
}
