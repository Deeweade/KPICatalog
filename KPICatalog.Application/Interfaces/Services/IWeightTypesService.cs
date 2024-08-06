using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IWeightTypesService
{
    Task<List<WeightTypeView>> GetAll();
}
