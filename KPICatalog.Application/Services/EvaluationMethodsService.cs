using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class EvaluationMethodsService : IEvaluationMethodsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EvaluationMethodsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<EvaluationMethodView>> GetAll()
    {
        var methods = await _unitOfWork.EvaluationMethodsRepository.GetAll();

        return _mapper.Map<List<EvaluationMethodView>>(methods);
    }
}
