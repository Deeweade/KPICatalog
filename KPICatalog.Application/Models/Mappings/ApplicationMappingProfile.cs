using KPICatalog.Application.Models.Filters;
using KPICatalog.Domain.Models.Filters;
using KPICatalog.Application.Models.Entities;
using KPICatalog.Domain.Models.Entities;
using AutoMapper;

namespace KPICatalog.Application.Models.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        //filters
        CreateMap<BonusSchemeFilterDto, BonusSchemesFilter>();

        //entities
        CreateMap<BonusScheme, BonusSchemeDto>();

        //collections
        CreateMap<IEnumerable<BonusScheme>, IEnumerable<BonusSchemeDto>>();
    }
}
