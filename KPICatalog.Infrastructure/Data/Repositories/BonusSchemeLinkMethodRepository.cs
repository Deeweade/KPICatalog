using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class BonusSchemeLinkMethodRepository : IBonusSchemeLinkMethodRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public BonusSchemeLinkMethodRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BonusSchemeLinkMethodDto>> GetAll()
    {
        return await _context.BonusSchemeLinkMethods
            .AsNoTracking()
            .ProjectTo<BonusSchemeLinkMethodDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
