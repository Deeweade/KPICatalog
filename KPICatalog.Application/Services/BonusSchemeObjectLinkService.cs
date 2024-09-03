using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;

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

    public async Task<IEnumerable<BonusSchemeObjectLinkView>> BulkCreate(BonusSchemeObjectLinkView linkView)
    {
        if (linkView is null) throw new ArgumentNullException(nameof(linkView));

        var filter = new BonusSchemeObjectLinkFilterDto
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
            new BonusSchemeObjectLinkFilterDto
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
