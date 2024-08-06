using KPICatalog.Domain.Models.Entities.KPICatalog;
using KPICatalog.Domain.Models.Entities.Goals;
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
        CreatePeriodMappings();
        CreateRatingScaleValueMappings();
        CreateEvaluationMethodMappings();
        CreateBonusShemeLinkMethodMappings();
        CreateWeightTypeMappings();
        CreatePlanningCycleMappings();
        CreateBonusSchemeLinkMethodMappings();
    }

    private void CreateBonusSchemeLinkMethodMappings()
    {
        CreateMap<BonusSchemeLinkMethod, BonusSchemeLinkMethodDto>();
        CreateMap<BonusSchemeLinkMethodDto, BonusSchemeLinkMethod>();
    }

    private void CreatePlanningCycleMappings()
    {
        CreateMap<PlanningCycle, PlanningCycleDto>();
        CreateMap<PlanningCycleDto, PlanningCycle>();
    }

    private void CreateWeightTypeMappings()
    {
        CreateMap<WeightType, WeightTypeDto>();
        CreateMap<WeightTypeDto, WeightType>();
    }

    private void CreateBonusShemeLinkMethodMappings()
    {
        CreateMap<BonusSchemeLinkMethod, BonusSchemeLinkMethodDto>();
        CreateMap<BonusSchemeLinkMethodDto, BonusSchemeLinkMethod>();
    }

    private void CreateEvaluationMethodMappings()
    {
        CreateMap<EvaluationMethod, EvaluationMethodDto>();
        CreateMap<EvaluationMethodDto, EvaluationMethod>();
    }

    private void CreateRatingScaleValueMappings()
    {
        CreateMap<RatingScaleValue, RatingScaleValueDto>();
        CreateMap<RatingScaleValueDto, RatingScaleValue>();
    }

    private void CreatePeriodMappings()
    {
        CreateMap<Period, PeriodDto>();
        CreateMap<PeriodDto, Period>();
    }

    private void CreateTypicalGoalInBonusSchemeMapping()
    {
        CreateMap<TypicalGoalInBonusScheme, TypicalGoalInBonusSchemeDto>()
            .ForMember(dest => dest.EvaluationMethod, opt => opt.MapFrom(src => src.EvaluationMethod))
            .ForMember(dest => dest.BonusSchemeLinkMethod, opt => opt.MapFrom(src => src.BonusSchemeLinkMethod))
            .ForMember(dest => dest.TypicalGoal, opt => opt.MapFrom(src => src.TypicalGoal));
        CreateMap<TypicalGoalInBonusSchemeDto, TypicalGoalInBonusScheme>()
            .ForMember(dest => dest.EvaluationMethod, opt => opt.MapFrom(src => src.EvaluationMethod))
            .ForMember(dest => dest.BonusSchemeLinkMethod, opt => opt.MapFrom(src => src.BonusSchemeLinkMethod))
            .ForMember(dest => dest.TypicalGoal, opt => opt.MapFrom(src => src.TypicalGoal));;
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
