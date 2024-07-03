
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IPeriodsRepository
{
    Task<IEnumerable<PeriodDto>> GetAll();
}
