
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IPeriodsRepository
{
    Task<PeriodDto> GetById(int periodId);
    Task<IEnumerable<PeriodDto>> GetAll();
    Task<List<PeriodDto>> GetParents(List<int> periodIds);
}