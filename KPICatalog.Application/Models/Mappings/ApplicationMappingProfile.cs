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
        CreateMap<BonusSchemeLinkMethodView, BonusSchemeLinkMethodDto>().ReverseMap();
        CreateMap<BonusSchemeObjectLinkView, BonusSchemeObjectLinkDto>().ReverseMap();
        CreateMap<BonusSchemeLinkMethodView, BonusSchemeLinkMethodDto>().ReverseMap();
        CreateMap<BonusSchemeFilterView, BonusSchemeFilterDto>().ReverseMap();
        CreateMap<EvaluationMethodView, EvaluationMethodDto>().ReverseMap();
        CreateMap<RatingScaleValueView, RatingScaleValueDto>().ReverseMap();
        CreateMap<PlanningCycleView, PlanningCycleDto>().ReverseMap();
        CreateMap<BonusSchemeView, BonusSchemeDto>().ReverseMap();
        CreateMap<TypicalGoalView, TypicalGoalDto>().ReverseMap();
        CreateMap<WeightTypeView, WeightTypeDto>().ReverseMap();
        CreateMap<EmployeeView, EmployeeDto>().ReverseMap();
        
        CreateMap<RatingScaleView, RatingScaleDto>()
            .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.Values))
            .ReverseMap();
        
        CreateMap<TypicalGoalInBonusSchemeView, TypicalGoalInBonusSchemeDto>()
            .ForMember(dest => dest.EvaluationMethod, opt => opt.MapFrom(src => src.EvaluationMethod))
            .ForMember(dest => dest.BonusSchemeLinkMethod, opt => opt.MapFrom(src => src.BonusSchemeLinkMethod))
            .ForMember(dest => dest.TypicalGoal, opt => opt.MapFrom(src => src.TypicalGoal))
            .ForMember(dest => dest.RatingScale, opt => opt.MapFrom(src => src.RatingScale))
            .ReverseMap();
    }
}
