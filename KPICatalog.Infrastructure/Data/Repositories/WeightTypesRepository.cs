using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class WeightTypesRepository : IWeightTypesRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public WeightTypesRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WeightTypeDto>> GetAll()
    {
        return await _context.WeightTypes
            .AsNoTracking()
            .ProjectTo<WeightTypeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
