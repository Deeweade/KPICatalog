using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class BonusSchemeLinkMethodService : IBonusSchemeLinkMethodService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BonusSchemeLinkMethodService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<BonusSchemeLinkMethodView>> GetAll()
    {
        var methods = await _unitOfWork.BonusSchemeLinkMethodRepository.GetAll();

        return _mapper.Map<List<BonusSchemeLinkMethodView>>(methods);
    }
}
