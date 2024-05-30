using KPICatalog.Domain.Models.Entities;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper;

namespace KPICatalog.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateBonusSchemeMappings();
        CreateBonusSchemeObjectLinkMappings();
        CreateUserAccessControlMappings();
    }

    private void CreateBonusSchemeObjectLinkMappings()
    {
        //entities
        CreateMap<BonusSchemeObjectLink, BonusSchemeObjectLinkDto>();
        CreateMap<BonusSchemeObjectLinkDto, BonusSchemeObjectLink>();

        //collections
        CreateMap<IEnumerable<BonusSchemeObjectLink>, IEnumerable<BonusSchemeObjectLinkDto>>();
        CreateMap<IEnumerable<BonusSchemeObjectLinkDto>, IEnumerable<BonusSchemeObjectLink>>();
    }

    private void CreateUserAccessControlMappings()
    {
        //entities
        CreateMap<UserAccessControl, UserAccessControlDto>();
        CreateMap<UserAccessControlDto, UserAccessControl>();
    }

    private void CreateBonusSchemeMappings()
    {
        //entities
        CreateMap<BonusScheme, BonusSchemeDto>();
        CreateMap<BonusSchemeDto, BonusScheme>();

        //collections
        CreateMap<IEnumerable<BonusScheme>, IEnumerable<BonusSchemeDto>>();
        CreateMap<IEnumerable<BonusSchemeDto>, IEnumerable<BonusScheme>>();
    }
}
