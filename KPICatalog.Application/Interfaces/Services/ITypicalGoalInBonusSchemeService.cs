
using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface ITypicalGoalInBonusSchemeService
{
    Task<IEnumerable<TypicalGoalInBonusSchemeView>> GetByTypicalGoalId(int goalId);
    Task BulkCreate(ICollection<int> bonusSchemesIds, ICollection<TypicalGoalView> typicalGoals);
    Task<GoalsForEmployeesRequestView> SendIntoMyGoals(int bonusSchemeId);
}
