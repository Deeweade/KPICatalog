using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class RatingScalesService : IRatingScalesService
{
    private readonly IRatingScalesRepository _repository;
    private readonly IMapper _mapper;

    public RatingScalesService(IRatingScalesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<RatingScaleView>> GetAll()
    {
        var scales = await _repository.GetAll();

        return _mapper.Map<List<RatingScaleView>>(scales);
    }
}
