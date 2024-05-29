using KPICatalog.Application.Models.Entities;
using KPICatalog.Application.Models.Filters;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;

namespace KPICatalog.Application.Models.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        //filters
        CreateMap<BonusSchemeFilterView, BonusSchemeFilterDto>();
        CreateMap<BonusSchemeFilterDto, BonusSchemeFilterView>();

        //entities
        CreateMap<BonusSchemeView, BonusSchemeDto>();
        CreateMap<BonusSchemeDto, BonusSchemeView>();

        //collections
        CreateMap<IEnumerable<BonusSchemeView>, IEnumerable<BonusSchemeDto>>();
        CreateMap<IEnumerable<BonusSchemeDto>, IEnumerable<BonusSchemeView>>();
    }
}
