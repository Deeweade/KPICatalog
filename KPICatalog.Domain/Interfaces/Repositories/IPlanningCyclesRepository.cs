
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IPlanningCyclesRepository
{
    Task<List<PlanningCycleDto>> GetAll();
}
