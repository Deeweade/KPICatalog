using AutoMapper;
using AutoMapper.QueryableExtensions;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Domain.Models.Entities;
using KPICatalog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

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
            .ProjectTo<BonusSchemeObjectLinkDto>(_mapper.ConfigurationProvider);

        if (filter.LinkedObjectsIds != null && filter.LinkedObjectsIds.Any())
        {
            query = query.Where(x => filter.LinkedObjectsIds.Any(id => id == x.LinkedObjectId));
        }

        return await query.ToListAsync();
    }

    public async Task<BonusSchemeObjectLinkDto> Create(BonusSchemeObjectLinkDto linkDto)
    {
        if (linkDto is null) throw new ArgumentNullException(nameof(linkDto));

        var link = _mapper.Map<BonusSchemeObjectLink>(linkDto);

        _context.BonusSchemeObjectLinks.Add(link);

        await _context.SaveChangesAsync();

        return await _context.BonusSchemeObjectLinks
            .AsNoTracking()
            .ProjectTo<BonusSchemeObjectLinkDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == link.Id);
    }

    public async Task Delete(BonusSchemeObjectLinkDto linkDto)
    {
        if (linkDto is null) throw new ArgumentNullException(nameof(linkDto));

        var link = await _context.BonusSchemeObjectLinks.FirstOrDefaultAsync(x => x.Id == linkDto.Id);

        _context.BonusSchemeObjectLinks.Remove(link);

        await _context.SaveChangesAsync();
    }
}
