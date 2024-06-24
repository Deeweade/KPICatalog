using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Models.Entities.KPICatalog;

namespace KPICatalog.Application.Interfaces.Services;

public interface ITypicalGoalService
{
    Task<TypicalGoalView> GetById(int goalId);
    Task<IEnumerable<TypicalGoalView>> GetAll();
    Task<IEnumerable<BonusSchemeView>> GetCurrent(int goalId, int typicalGoalTypeId);
    Task<IEnumerable<TypicalGoalInBonusSchemeView>> GetGoalsInBS();
    Task<TypicalGoalView?> Create(TypicalGoalView typicalGoalView);
    Task<TypicalGoalView?> Update(TypicalGoalView typicalGoalView);
}