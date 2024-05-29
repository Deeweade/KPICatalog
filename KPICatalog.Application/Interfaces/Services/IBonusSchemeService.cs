using KPICatalog.Application.Models.Entities;
using KPICatalog.Application.Models.Filters;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeService
{
    Task<BonusSchemeDto?> GetById(int schemeId);
    Task<IEnumerable<BonusSchemeDto>> GetByFilter(BonusSchemeFilterDto filterDto);
}
