using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Linq.Expressions;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class BonusSchemeObjectLinkRepository : IBonusSchemeObjectLinkRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public BonusSchemeObjectLinkRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TResult>> GetByFilter<TResult>(BonusSchemeObjectLinkQueryDto queryDto, Expression<Func<BonusSchemeObjectLinkDto, TResult>> select = null)
    {
        if (queryDto is null) throw new ArgumentNullException(nameof(queryDto));

        var query = _context.BonusSchemeObjectLinks
            .AsNoTracking()
            .ProjectTo<BonusSchemeObjectLinkDto>(_mapper.ConfigurationProvider);

        if (queryDto.IsActive is not null)
        {
            query = query.Where(x => x.IsActive == queryDto.IsActive);
        }

        if (queryDto.LinkedObjectsIds != null && queryDto.LinkedObjectsIds.Any())
        {
            query = query.Where(x => queryDto.LinkedObjectsIds.Any(id => id == x.LinkedObjectId));
        }

        if (queryDto.BonusSchemeId is not null)
        {
            query = query.Where(x => x.BonusSchemeId == queryDto.BonusSchemeId);
        }

        if (queryDto.LinkedObjectTypeId is not null)
        {
            query = query.Where(x => x.LinkedObjectTypeId == queryDto.LinkedObjectTypeId);    
        }

        if (queryDto.EffectiveDate is not null)
        {
            query = query.Where(x => x.DateStart <= queryDto.EffectiveDate && x.DateEnd > queryDto.EffectiveDate);
        }

        if (queryDto.PeriodDateStart is not null && queryDto.PeriodDateEnd is not null)
        {
            query = query.Where(x => x.DateEnd >= queryDto.PeriodDateStart && x.DateStart <= queryDto.PeriodDateEnd);
        }

        if (select is not null)
        {
            return await query.Select(select).ToListAsync();
        }
        else
        {
            return await query.Cast<TResult>().ToListAsync();
        }
    }

    public async Task<BonusSchemeObjectLinkDto> Create(BonusSchemeObjectLinkDto linkDto)
    {
        if (linkDto is null) throw new ArgumentNullException(nameof(linkDto));

        if (linkDto.DateStart is null) linkDto.DateStart = DateTime.Now;
        if (linkDto.DateEnd is null) linkDto.DateEnd = DateTime.MaxValue;

        var link = _mapper.Map<BonusSchemeObjectLink>(linkDto);

        link.IsActive = true;

        _context.BonusSchemeObjectLinks.Add(link);

        await _context.SaveChangesAsync();

        return await _context.BonusSchemeObjectLinks
            .AsNoTracking()
            .ProjectTo<BonusSchemeObjectLinkDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == link.Id);
    }

    public async Task BulkCreate(BonusSchemeObjectLinkDto linkDto)
    {
        if (linkDto is null) throw new ArgumentNullException(nameof(linkDto));

        if (linkDto.DateStart is null) linkDto.DateStart = DateTime.Now;
        if (linkDto.DateEnd is null) linkDto.DateEnd = DateTime.MaxValue;

        foreach (var objectId in linkDto.LinkedObjectsIds)
        {
            var link = _mapper.Map<BonusSchemeObjectLink>(linkDto);

            link.LinkedObjectId = objectId;
            link.IsActive = true;

            _context.BonusSchemeObjectLinks.Add(link);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<BonusSchemeObjectLinkDto> Delete(BonusSchemeObjectLinkDto linkDto)
    {
        if (linkDto is null) throw new ArgumentNullException(nameof(linkDto));

        var link = await _context.BonusSchemeObjectLinks.FirstOrDefaultAsync(x => x.Id == linkDto.Id);

        link.DateEnd = linkDto.DateEnd ?? DateTime.Now;
        link.IsActive = false;

        await _context.SaveChangesAsync();

        return _mapper.Map<BonusSchemeObjectLinkDto>(link);
    }
}
