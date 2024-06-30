using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface ITypicalGoalInBonusSchemeRepository
{
    Task<IEnumerable<TypicalGoalInBonusSchemeDto>> GetByIds(IEnumerable<int> ids);
    Task<IEnumerable<TypicalGoalInBonusSchemeDto>> GetByTypicalGoalId(int id);
    Task<TypicalGoalInBonusSchemeDto> Create(TypicalGoalInBonusSchemeDto goal);
    Task<IEnumerable<int>> BulkCreate(List<TypicalGoalInBonusSchemeDto> goalsInScheme);
    Task<IEnumerable<int>> BulkUpdate(List<TypicalGoalInBonusSchemeDto> children);
}