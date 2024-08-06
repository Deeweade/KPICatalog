using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class PlanningCyclesRepository : IPlanningCyclesRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public PlanningCyclesRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PlanningCycleDto>> GetAll()
    {
        return await _context.PlanningCycles
            .AsNoTracking()
            .ProjectTo<PlanningCycleDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
