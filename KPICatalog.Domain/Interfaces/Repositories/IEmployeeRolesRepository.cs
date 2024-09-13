
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using System.Linq.Expressions;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IEmployeeRolesRepository
{
    Task<List<TResult>> GetByQuery<TResult>(EmployeeRolesQueryDto employeeRolesQueryDto, Expression<Func<EmployeeRoleDto, TResult>> select = null);
}
