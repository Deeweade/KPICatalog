using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class RatingScalesRepository : IRatingScalesRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public RatingScalesRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RatingScaleDto>> GetAll()
    {
        return await _context.RatingScales
            .AsNoTracking()
            .ProjectTo<RatingScaleDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
