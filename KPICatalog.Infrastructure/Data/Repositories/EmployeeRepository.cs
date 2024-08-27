using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly PerfManagementDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeRepository(PerfManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> GetByIds(List<int> ids)
    {
        if (ids is null) throw new ArgumentNullException(nameof(ids));

        ids = ids.Distinct().ToList();

        return await _context.Employees
            .AsNoTracking()
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
    }
}
