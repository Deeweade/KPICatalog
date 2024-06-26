using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IBonusSchemeRepository
{
    Task<BonusSchemeDto?> GetById(int schemeId);
    Task<IEnumerable<string>> GetCostCenters();
    Task<IEnumerable<BonusSchemeDto>> GetByFilter(BonusSchemeFilterDto filter);
    Task<IEnumerable<BonusSchemeDto?>> GetByTypicalGoalId(int goalId);
    Task<BonusSchemeDto?> Create(BonusSchemeDto bonusSchemeDto);
    Task<BonusSchemeDto> Update(BonusSchemeDto schemeDto);
}
