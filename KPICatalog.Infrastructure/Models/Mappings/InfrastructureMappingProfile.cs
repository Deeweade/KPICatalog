using KPICatalog.Domain.Models.Entities;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper;

namespace KPICatalog.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        //entities
        CreateMap<BonusScheme, BonusSchemeDto>();
        CreateMap<BonusSchemeDto, BonusScheme>();
        CreateMap<UserAccessControl, UserAccessControlDto>();
        CreateMap<UserAccessControlDto, UserAccessControl>();

        //collections
        CreateMap<IEnumerable<BonusScheme>, IEnumerable<BonusSchemeDto>>();
        CreateMap<IEnumerable<BonusSchemeDto>, IEnumerable<BonusScheme>>();
    }
}
