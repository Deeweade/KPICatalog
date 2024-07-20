
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IBonusSchemeObjectLinkRepository
{
    Task<IEnumerable<BonusSchemeObjectLinkDto>> GetByFilter(BonusSchemeObjectLinkFilterDto filter);
    
    /// <summary>
    /// Создает одну запись в БД для значения в BonusSchemeObjectLinkDto.LinkedObjectsId
    /// </summary>
    /// <param name="linkDto"Принимает сущность BonusSchemeObjectLinkDto></param>
    /// <exception cref="ArgumentNullException"></exception>
    Task<BonusSchemeObjectLinkDto> Create(BonusSchemeObjectLinkDto link);
    
    /// <summary>
    /// Создает записи в БД для каждого значения в BonusSchemeObjectLinkDto.LinkedObjectsIds
    /// </summary>
    /// <param name="linkDto"Принимает сущность BonusSchemeObjectLinkDto></param>
    /// <exception cref="ArgumentNullException"></exception>
    Task BulkCreate(BonusSchemeObjectLinkDto linkDto);
    Task Delete(BonusSchemeObjectLinkDto link);
}
