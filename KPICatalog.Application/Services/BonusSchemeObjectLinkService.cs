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

    public async Task<IEnumerable<BonusSchemeObjectLinkView>> CreateMany(BonusSchemeObjectLinkView linkView)
    {
        if (linkView is null) throw new ArgumentNullException(nameof(linkView));

        var filter = new BonusSchemeObjectLinkFilterDto
        {
            LinkedObjectsIds = linkView.LinkedObjectsIds
        };

        //Удаляем существующие связи для объектов, если они есть
        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter);

        if (links is not null && links.Any())
        {
            foreach(var link in links)
            {
                await _unitOfWork.BonusSchemeObjectLinkRepository.Delete(link);
            }
        }

        //Создаем новые связи
        var dto = new BonusSchemeObjectLinkDto
        {
            BonusSchemeId = linkView.BonusSchemeId,
            LinkedObjectTypeId = linkView.LinkedObjectTypeId,
            LinkedObjectsIds = linkView.LinkedObjectsIds
        };

        await _unitOfWork.BonusSchemeObjectLinkRepository.BulkCreate(dto);

        await _unitOfWork.SaveChangesAsync();

        //Возвращаем созданные объекты
        links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter);

        return _mapper.Map<IEnumerable<BonusSchemeObjectLinkView>>(links);
    }

    public async Task<IEnumerable<BonusSchemeObjectLinkView>> Delete(BonusSchemeObjectLinkView linkView)
    {
        var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(
            new BonusSchemeObjectLinkFilterDto
            {
                LinkedObjectsIds = linkView.LinkedObjectsIds,
                LinkedObjectTypeId = linkView.LinkedObjectTypeId
            });

        foreach(var link in links.DefaultIfEmpty())
        {
            await _unitOfWork.BonusSchemeObjectLinkRepository.Delete(link!);
        }

        return _mapper.Map<IEnumerable<BonusSchemeObjectLinkView>>(links);
    }
}
