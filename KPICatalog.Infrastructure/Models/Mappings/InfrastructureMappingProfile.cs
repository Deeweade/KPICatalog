using KPICatalog.Domain.Models.Entities;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper;

namespace KPICatalog.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateTypicalGoalInBonusSchemeMapping();
        CreateTypicalGoalMappings();
        CreateEmployeeMappings();
        CreateBonusSchemeObjectLinkMappings();
        CreateBonusSchemeMappings();
        CreateUserAccessControlMappings();
    }

    private void CreateTypicalGoalInBonusSchemeMapping()
    {
        CreateMap<TypicalGoalInBonusScheme, TypicalGoalInBonusSchemeDto>();
        CreateMap<TypicalGoalInBonusSchemeDto, TypicalGoalInBonusScheme>();
    }

    private void CreateTypicalGoalMappings()
    {
        CreateMap<TypicalGoal, TypicalGoalDto>();
        CreateMap<TypicalGoalDto, TypicalGoal>();
    }

    private void CreateEmployeeMappings()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>();
    }

    private void CreateBonusSchemeObjectLinkMappings()
    {
        //entities
        CreateMap<BonusSchemeObjectLink, BonusSchemeObjectLinkDto>();
        CreateMap<BonusSchemeObjectLinkDto, BonusSchemeObjectLink>();
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
    }
}
