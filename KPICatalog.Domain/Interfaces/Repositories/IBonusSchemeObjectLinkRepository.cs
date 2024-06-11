
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IBonusSchemeObjectLinkRepository
{
    Task<IEnumerable<BonusSchemeObjectLinkDto>> GetByFilter(BonusSchemeObjectLinkFilterDto filter);
    Task<BonusSchemeObjectLinkDto> Create(BonusSchemeObjectLinkDto link);
    Task Delete(BonusSchemeObjectLinkDto link);
}
