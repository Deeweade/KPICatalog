using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Filters;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;
using KPICatalog.Domain.Models.Enums;

namespace KPICatalog.Application.Services;

public class BonusSchemeObjectLinkService : IBonusSchemeObjectLinkService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BonusSchemeObjectLinkService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<List<BonusSchemeObjectLinkView>> GetByQuery(BonusSchemeObjectLinkQueryView queryView)
    {
        ArgumentNullException.ThrowIfNull(queryView);

        var employee = await _unitOfWork.EmployeeRepository.GetByLogin(queryView.Login);

        var queryDto = new BonusSchemeObjectLinkQueryDto();

        queryDto.LinkedObjectsIds = new List<int> { employee.Id };
        queryDto.LinkedObjectTypeId = (int)LinkedObjectTypes.Employee;


        if (queryView.PeriodId is null)
        {
            queryDto.EffectiveDate = queryView.EffectiveDate;

            var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(queryDto, x => x);

            var views = _mapper.Map<List<BonusSchemeObjectLinkView>>(links);

            views.ForEach(x => x.BonusScheme.IsCurrentBSforEffectiveDate = true);

            return views;
        }
        else
        {
            var period = await _unitOfWork.PeriodsRepository.GetById(queryView.PeriodId.Value);

            queryDto.PeriodDateStart = period.DateStart;
            queryDto.PeriodDateEnd = period.DateEnd;
            queryDto.EffectiveDate = null;
            
            var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(queryDto, x => x);

            var views = _mapper.Map<List<BonusSchemeObjectLinkView>>(links);

            foreach(var link in views)
            {
                if (link.BonusScheme.DateStart <= queryView.EffectiveDate
                    && link.BonusScheme.DateEnd > queryView.EffectiveDate)
                {
                    link.BonusScheme.IsCurrentBSforEffectiveDate = true;
                }
                else
                {
                    link.BonusScheme.IsCurrentBSforEffectiveDate = false;
                }
            }

            return views;
        }
    }

    public async Task<IEnumerable<BonusSchemeObjectLinkView>> BulkCreate(BonusSchemeObjectLinkView linkView)
    {
        if (linkView is null) throw new ArgumentNullException(nameof(linkView));

        var filter = new BonusSchemeObjectLinkQueryDto
        {
            LinkedObjectsIds = linkView.LinkedObjectsIds
        };

        //Удаляем существующие связи для объектов, если они есть
        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter, x => x);

        if (links is not null && links.Any())
        {
            foreach(var link in links)
            {
                link.DateEnd = linkView.DateStart ?? DateTime.Now;
                await _unitOfWork.BonusSchemeObjectLinkRepository.Delete(link);
            }
        }

        //Создаем новые связи
        var dto = new BonusSchemeObjectLinkDto
        {
            BonusSchemeId = linkView.BonusSchemeId,
            LinkedObjectTypeId = linkView.LinkedObjectTypeId,
            LinkedObjectsIds = linkView.LinkedObjectsIds,
            LinkPercent = linkView.LinkPercent,
            DateStart = linkView.DateStart,
            DateEnd = linkView.DateEnd
        };

        await _unitOfWork.BonusSchemeObjectLinkRepository.BulkCreate(dto);

        await _unitOfWork.SaveChangesAsync();

        //Возвращаем созданные объекты
        links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter, x => x);

        return _mapper.Map<IEnumerable<BonusSchemeObjectLinkView>>(links);
    }

    public async Task<IEnumerable<BonusSchemeObjectLinkView>> Delete(BonusSchemeObjectLinkView linkView)
    {
        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(
            new BonusSchemeObjectLinkQueryDto
            {
                LinkedObjectsIds = linkView.LinkedObjectsIds,
                LinkedObjectTypeId = linkView.LinkedObjectTypeId
            },
            x => x);
        
        var deletedLinks = new List<BonusSchemeObjectLinkDto>();

        foreach(var link in links)
        {
            var deletedLink = await _unitOfWork.BonusSchemeObjectLinkRepository.Delete(link!);

            deletedLinks.Add(deletedLink);
        }

        return _mapper.Map<IEnumerable<BonusSchemeObjectLinkView>>(deletedLinks);
    }
}
