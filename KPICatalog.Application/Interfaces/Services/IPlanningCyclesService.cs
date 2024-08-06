using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IPlanningCyclesService
{
    Task<List<PlanningCycleView>> GetAll();
}
