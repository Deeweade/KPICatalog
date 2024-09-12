using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<EmployeeDto> GetByLogin(string login);
    Task<IEnumerable<EmployeeDto>> GetByIds(List<int> ids);
}
