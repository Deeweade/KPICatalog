using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class EmployeeRolesRepository : IEmployeeRolesRepository
{
    private readonly PerfManagementDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeRolesRepository(PerfManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TResult>> GetByQuery<TResult>(EmployeeRolesQueryDto queryDto, 
        Expression<Func<EmployeeRolesDto, TResult>> select = null)
    {
        ArgumentNullException.ThrowIfNull(queryDto);

        var query = _context.EmployeeRoles
            .AsNoTracking()
            .ProjectTo<EmployeeRolesDto>(_mapper.ConfigurationProvider);

        if (queryDto.RoleIds is not null)
        {
            query = query.Where(x => queryDto.RoleIds.Contains(x.RoleId));
        }

        if (queryDto.EmployeeIds is not null)
        {
            query = query.Where(x => queryDto.EmployeeIds.Contains(x.EmployeeId));
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
}
