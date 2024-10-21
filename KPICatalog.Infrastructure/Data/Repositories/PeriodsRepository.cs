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

    public async Task<PeriodDto> GetById(int periodId)
    {
        return await _context.Periods
            .AsNoTracking()
            .ProjectTo<PeriodDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == periodId);
    }

    public async Task<List<PeriodDto>> GetParents(List<int> childrenPeriodIds)
    {
        ArgumentNullException.ThrowIfNull(childrenPeriodIds);

        var childrenPeriods = await _context.Periods
            .AsNoTracking()
            .Where(x => childrenPeriodIds.Contains(x.Id))
            .ToListAsync();

        var parentIds = new List<int>();

        foreach (var childrenPeriod in childrenPeriods)
        {
            var periodId = await _context.Periods
                .AsNoTracking()
                .Where(x => x.NumberY == childrenPeriod.NumberY 
                    && x.IsYear == 1)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            parentIds.Add(periodId);
        }

        parentIds = parentIds.Distinct().ToList();

        return await _context.Periods
            .AsNoTracking()
            .ProjectTo<PeriodDto>(_mapper.ConfigurationProvider)
            .Where(x => parentIds.Contains(x.Id))
            .ToListAsync();
    }
}
