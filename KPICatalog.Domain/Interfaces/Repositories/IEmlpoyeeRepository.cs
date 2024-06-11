using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IEmlpoyeeRepository
{
    Task<IEnumerable<EmployeeDto>> GetByIds(List<int> ids);
}
