using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;

namespace KPICatalog.Application.Models.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateBonusSchemeMappings();
        CreateBonusSchemeObjectLinkMappings();
    }

    private void CreateBonusSchemeObjectLinkMappings()
    {
        //entities
        CreateMap<BonusSchemeObjectLinkView, BonusSchemeObjectLinkDto>();
        CreateMap<BonusSchemeObjectLinkDto, BonusSchemeObjectLinkView>();
    }

    private void CreateBonusSchemeMappings()
    {
        //filters
        CreateMap<BonusSchemeFilterView, BonusSchemeFilterDto>();
        CreateMap<BonusSchemeFilterDto, BonusSchemeFilterView>();

        //entities
        CreateMap<BonusSchemeView, BonusSchemeDto>();
        CreateMap<BonusSchemeDto, BonusSchemeView>();
    }
}
