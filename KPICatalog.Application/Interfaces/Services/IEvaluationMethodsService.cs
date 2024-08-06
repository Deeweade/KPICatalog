using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IEvaluationMethodsService
{
    Task<List<EvaluationMethodView>> GetAll();
}
