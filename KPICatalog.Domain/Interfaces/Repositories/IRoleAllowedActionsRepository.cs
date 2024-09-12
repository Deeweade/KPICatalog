using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using System.Linq.Expressions;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IRoleAllowedActionsRepository
{
    Task<List<TResult>> GetByQuery<TResult>(RoleAllowedActionQueryDto roleAllowedActionsQueryDto, Expression<Func<RoleAllowedActionDto, TResult>> select = null);
}
