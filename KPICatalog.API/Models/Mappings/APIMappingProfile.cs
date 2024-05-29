using KPICatalog.Application.Models.Filters;
using KPICatalog.API;
using AutoMapper;

public class APIMappingProfile : Profile
{
    public APIMappingProfile()
    {
        CreateMap<BonusSchemeFilterView, BonusSchemeFilterDto>();
    }
}