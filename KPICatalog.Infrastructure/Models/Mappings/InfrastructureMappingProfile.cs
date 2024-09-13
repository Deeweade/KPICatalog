using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Models.Entities.Goals;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper;
using Action = KPICatalog.Domain.Models.Entities.Goals.Action;

namespace KPICatalog.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateMap<BonusSchemeObjectLink, BonusSchemeObjectLinkDto>().ReverseMap();
        CreateMap<BonusSchemeLinkMethod, BonusSchemeLinkMethodDto>().ReverseMap();
        CreateMap<UserAccessControl, UserAccessControlDto>().ReverseMap();
        CreateMap<RoleAllowedAction, RoleAllowedActionDto>().ReverseMap();
        CreateMap<EvaluationMethod, EvaluationMethodDto>().ReverseMap();
        CreateMap<RatingScaleValue, RatingScaleValueDto>().ReverseMap();
        CreateMap<PlanningCycle, PlanningCycleDto>().ReverseMap();
        CreateMap<EmployeeRole, EmployeeRoleDto>().ReverseMap();
        CreateMap<TypicalGoal, TypicalGoalDto>().ReverseMap();
        CreateMap<BonusScheme, BonusSchemeDto>().ReverseMap();
        CreateMap<WeightType, WeightTypeDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Period, PeriodDto>().ReverseMap();
        CreateMap<Action, ActionDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
        
        CreateMap<RatingScale, RatingScaleDto>()
            .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.Values))
            .ReverseMap();

        CreateMap<TypicalGoalInBonusScheme, TypicalGoalInBonusSchemeDto>()
            .ForMember(dest => dest.EvaluationMethod, opt => opt.MapFrom(src => src.EvaluationMethod))
            .ForMember(dest => dest.BonusSchemeLinkMethod, opt => opt.MapFrom(src => src.BonusSchemeLinkMethod))
            .ForMember(dest => dest.TypicalGoal, opt => opt.MapFrom(src => src.TypicalGoal))
            .ForMember(dest => dest.RatingScale, opt => opt.MapFrom(src => src.RatingScale))
            .ReverseMap();
    }
}
