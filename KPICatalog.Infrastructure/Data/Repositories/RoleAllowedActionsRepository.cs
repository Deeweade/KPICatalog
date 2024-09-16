using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class RoleAllowedActionsRepository : IRoleAllowedActionsRepository
{
    private readonly PerfManagementDbContext _context;
    private readonly IMapper _mapper;

    public RoleAllowedActionsRepository(PerfManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TResult>> GetByQuery<TResult>(RoleAllowedActionQueryDto queryDto, 
        Expression<Func<RoleAllowedActionDto, TResult>> select = null)
    {
        ArgumentNullException.ThrowIfNull(queryDto);

        var query = _context.RoleAllowedActions
            .AsNoTracking()
            .ProjectTo<RoleAllowedActionDto>(_mapper.ConfigurationProvider);

        if (queryDto.RolesIds is not null)
        {
            query = query.Where(x => queryDto.RolesIds.Contains(x.RoleId));
        }

        if (queryDto.ActionsIds is not null)
        {
            query = query.Where(x => queryDto.ActionsIds.Contains(x.ActionId));
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
