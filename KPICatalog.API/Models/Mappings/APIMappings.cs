using KPICatalog.Application.Models.Views;
using KPICatalog.API.Models.Other;
using AutoMapper;

namespace KPICatalog.API.Models.Mappings;

public class APIMappings : Profile
{
    public APIMappings()
    {
        CreateBulkEvaluationViewMappings();
    }

    private void CreateBulkEvaluationViewMappings()
    {
        CreateMap<BulkEvaluateView, BulkEvaluateGoalsView>();
        CreateMap<BulkEvaluateGoalsView, BulkEvaluateView>();
    }
}
