using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure;

public class BonusSchemeRepository : IBonusSchemeRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public BonusSchemeRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BonusSchemeDto?> GetById(int schemeId)
    {
        if (schemeId <= 0) throw new ArgumentOutOfRangeException(nameof(schemeId));

        return await _context.BonusSchemes
            .AsNoTracking()
            .ProjectTo<BonusSchemeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == schemeId);
    }

    public async Task<IEnumerable<string>> GetCostCenters()
    {
        return await _context.BonusSchemes
            .AsNoTracking()
            .Select(x => x.CostCenter)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<BonusSchemeDto>> GetByFilter(BonusSchemeFilterDto filter)
    {
        if (filter is null) throw new ArgumentNullException(nameof(filter));

        var query = _context.BonusSchemes
            .AsNoTracking()
            .ProjectTo<BonusSchemeDto>(_mapper.ConfigurationProvider);

        if (filter.IncludeActiveOnly is not null && (bool)filter.IncludeActiveOnly)
        {
            query = query.Where(x => x.IsActive);
        }

        var res = await query.ToListAsync();

        return res;
    }

    public async Task<BonusSchemeDto?> Create(BonusSchemeDto bonusSchemeDto)
    {
        if (bonusSchemeDto is null) throw new ArgumentNullException(nameof(bonusSchemeDto));

        var scheme = _mapper.Map<BonusScheme>(bonusSchemeDto);

        _context.Add(scheme);

        await _context.SaveChangesAsync();

        return await GetById(scheme.Id);
    }

    public async Task<BonusSchemeDto> Update(BonusSchemeDto bonusSchemeDto)
    {
        if (bonusSchemeDto is null) throw new ArgumentNullException(nameof(bonusSchemeDto));

        var scheme = await _context.BonusSchemes.FirstOrDefaultAsync(x => x.Id == bonusSchemeDto.Id);

        scheme.Title = bonusSchemeDto.Title;
        scheme.CostCenter = bonusSchemeDto.CostCenter;
        scheme.ExternalId = bonusSchemeDto.ExternalId;
        scheme.IsDefaulBonusScheme = bonusSchemeDto.IsDefaulBonusScheme;
        scheme.PlanningCycleId = bonusSchemeDto.PlanningCycleId;
        scheme.DateStart = bonusSchemeDto.DateStart;
        scheme.DateEnd = bonusSchemeDto.DateEnd;
        scheme.IsActive = bonusSchemeDto.IsActive;

        await _context.SaveChangesAsync();

        return await GetById(scheme.Id);
    }
}
