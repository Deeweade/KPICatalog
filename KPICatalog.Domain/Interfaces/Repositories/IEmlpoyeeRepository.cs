using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeDto>> GetByIds(List<int> ids);
}
