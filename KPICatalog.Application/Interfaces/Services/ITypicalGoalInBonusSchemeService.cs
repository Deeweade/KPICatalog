
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Application.Interfaces.Services;

public interface ITypicalGoalInBonusSchemeService
{
    Task<IEnumerable<TypicalGoalInBonusSchemeView?>> GetGoalsInBS();
    Task BulkCreate(ICollection<int> bonusSchemesIds, ICollection<TypicalGoalView> typicalGoals);
}
