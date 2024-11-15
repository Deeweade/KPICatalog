﻿using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IBonusSchemeRepository
{
    Task<BonusSchemeDto> GetById(int schemeId);
    Task<List<BonusSchemeDto>> GetByIds(List<int> bonusSchemeIds);
    Task<IEnumerable<string>> GetCostCenters();
    Task<IEnumerable<BonusSchemeDto>> GetByFilter(BonusSchemeFilterDto filter);
    Task<BonusSchemeDto> Create(BonusSchemeDto bonusSchemeDto);
    Task<BonusSchemeDto> Update(BonusSchemeDto schemeDto);
}
