using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class PeriodsRepository : IPeriodsRepository
{
    private readonly PerfManagementDbContext _context;
    private readonly IMapper _mapper;

    public PeriodsRepository(PerfManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PeriodDto>> GetAll()
    {
        return await _context.Periods
            .AsNoTracking()
            .ProjectTo<PeriodDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
