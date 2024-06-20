using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;
using KPICatalog.Domain.Models.Entities.KPICatalog;
using System.Security.Cryptography.X509Certificates;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Models.Enums;

namespace KPICatalog.Application.Services;

public class BonusSchemeObjectLinkService : IBonusSchemeObjectLinkService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly KPICatalogDbContext _context;

    public BonusSchemeObjectLinkService(IUnitOfWork unitOfWork, IMapper mapper, KPICatalogDbContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
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
        foreach (var objectId in linkView.LinkedObjectsIds)
        {
            var link = new BonusSchemeObjectLinkDto
            {
                BonusSchemeId = linkView.BonusSchemeId,
                LinkedObjectId = objectId,
                LinkedObjectTypeId = linkView.LinkedObjectTypeId
            };

            await _unitOfWork.BonusSchemeObjectLinkRepository.Create(link);
        }

        //Возвращаем созданные объекты
        links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(filter);

        return _mapper.Map<IEnumerable<BonusSchemeObjectLinkView>>(links);
    }

    public async Task<IEnumerable<BonusSchemeObjectLinkView>> Delete(IEnumerable<int> ids, int linkedObjectTypeId)
    {
        if (ids?.Any() == true)
        {
            var links = await _unitOfWork.BonusSchemeObjectLinkRepository.GetByFilter(
                new BonusSchemeObjectLinkFilterDto
                {
                    LinkedObjectsIds = ids.ToList(),
                    LinkedObjectTypeId = linkedObjectTypeId
                });

            foreach(var link in links.DefaultIfEmpty())
            {
                await _unitOfWork.BonusSchemeObjectLinkRepository.Delete(link!);
            }

            return _mapper.Map<IEnumerable<BonusSchemeObjectLinkView>>(links); 
        }

        return new List<BonusSchemeObjectLinkView>(0);
    }
}
