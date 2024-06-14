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
    }

    private void CreateTypicalGoalInBonusSchemeMappings()
    {
        CreateMap<TypicalGoalInBonusSchemeView, TypicalGoalInBonusSchemeDto>();
        CreateMap<TypicalGoalInBonusSchemeDto, TypicalGoalInBonusSchemeView>();
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
