using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Security.Cryptography.X509Certificates;

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

    public async Task<IEnumerable<BonusSchemeObjectLinkDto>> GetByFilter(BonusSchemeObjectLinkFilterDto filter)
    {
        if (filter is null) throw new ArgumentNullException(nameof(filter));

        var query = _context.BonusSchemeObjectLinks
            .AsNoTracking()
            .ProjectTo<BonusSchemeObjectLinkDto>(_mapper.ConfigurationProvider)
            .Where(x => x.IsActive);

        if (filter.LinkedObjectsIds != null && filter.LinkedObjectsIds.Any())
        {
            query = query.Where(x => filter.LinkedObjectsIds.Any(id => id == x.LinkedObjectId));
        }

        if (filter.BonusSchemeId is not null)
        {
            query = query.Where(x => x.BonusSchemeId == filter.BonusSchemeId);
        }

        if (filter.LinkedObjectTypeId is not null)
        {
            query = query.Where(x => x.LinkedObjectTypeId == filter.LinkedObjectTypeId);    
        }

        return await query.ToListAsync();
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

    public async Task Delete(BonusSchemeObjectLinkDto linkDto)
    {
        if (linkDto is null) throw new ArgumentNullException(nameof(linkDto));

        var link = await _context.BonusSchemeObjectLinks.FirstOrDefaultAsync(x => x.Id == linkDto.Id);

        link.DateEnd = linkDto.DateEnd ?? DateTime.Now;
        link.IsActive = false;

        await _context.SaveChangesAsync();
    }
}
