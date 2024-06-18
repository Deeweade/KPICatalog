using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface ITypicalGoalService
{
    Task<TypicalGoalView> GetById(int goalId);
    Task<TypicalGoalView> Create(TypicalGoalView typicalGoalView);
    Task<TypicalGoalView> Update(TypicalGoalView typicalGoalView);
}