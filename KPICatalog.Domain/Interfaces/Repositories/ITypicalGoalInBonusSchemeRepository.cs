using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface ITypicalGoalInBonusSchemeRepository
{
    Task<IEnumerable<TypicalGoalInBonusSchemeDto?>> GetGoalsInBS();
}