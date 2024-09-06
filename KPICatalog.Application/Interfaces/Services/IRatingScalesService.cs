using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IRatingScalesService
{
    Task<List<RatingScaleView>> GetAll();
}
