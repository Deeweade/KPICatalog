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
        CreateTypicalGoalInBonusSchemeMappings();
        CreateTypicalGoalMappings();
        CreateEmployeeMappings();
        CreateBonusSchemeMappings();
        CreateBonusSchemeObjectLinkMappings();
        CreateBonusShemeLinkMethodMappings();
        CreateEvaluationMethodMappings();
        CreateBonusSchemeLinkMethodMappings();
        CreatePlanningCycleMappings();
        CreateWeightTypeMappings();
    }

    private void CreateBonusSchemeLinkMethodMappings()
    {
        CreateMap<BonusSchemeLinkMethodView, BonusSchemeLinkMethodDto>();
        CreateMap<BonusSchemeLinkMethodDto, BonusSchemeLinkMethodView>();
    }

    private void CreatePlanningCycleMappings()
    {
        CreateMap<PlanningCycleView, PlanningCycleDto>();
        CreateMap<PlanningCycleDto, PlanningCycleView>();
    }

    private void CreateWeightTypeMappings()
    {
        CreateMap<WeightTypeView, WeightTypeDto>();
        CreateMap<WeightTypeDto, WeightTypeView>();
    }

    private void CreateBonusShemeLinkMethodMappings()
    {
        CreateMap<BonusSchemeLinkMethodView, BonusSchemeLinkMethodDto>();
        CreateMap<BonusSchemeLinkMethodDto, BonusSchemeLinkMethodView>();
    }

    private void CreateEvaluationMethodMappings()
    {
        CreateMap<EvaluationMethodView, EvaluationMethodDto>();
        CreateMap<EvaluationMethodDto, EvaluationMethodView>();
    }

    private void CreateTypicalGoalInBonusSchemeMappings()
    {
        CreateMap<TypicalGoalInBonusSchemeView, TypicalGoalInBonusSchemeDto>()
            .ForMember(dest => dest.EvaluationMethod, opt => opt.MapFrom(src => src.EvaluationMethod))
            .ForMember(dest => dest.BonusSchemeLinkMethod, opt => opt.MapFrom(src => src.BonusSchemeLinkMethod))
            .ForMember(dest => dest.TypicalGoal, opt => opt.MapFrom(src => src.TypicalGoal));
        CreateMap<TypicalGoalInBonusSchemeDto, TypicalGoalInBonusSchemeView>()
            .ForMember(dest => dest.EvaluationMethod, opt => opt.MapFrom(src => src.EvaluationMethod))
            .ForMember(dest => dest.BonusSchemeLinkMethod, opt => opt.MapFrom(src => src.BonusSchemeLinkMethod))
            .ForMember(dest => dest.TypicalGoal, opt => opt.MapFrom(src => src.TypicalGoal));
    }

    private void CreateTypicalGoalMappings()
    {
        CreateMap<TypicalGoalView, TypicalGoalDto>();
        CreateMap<TypicalGoalDto, TypicalGoalView>();
    }

    private void CreateEmployeeMappings()
    {
        CreateMap<EmployeeView, EmployeeDto>();
        CreateMap<EmployeeDto, EmployeeView>();
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
