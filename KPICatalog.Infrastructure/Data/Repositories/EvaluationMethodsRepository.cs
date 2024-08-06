using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Repositories;

public class EvaluationMethodsRepository : IEvaluationMethodsRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public EvaluationMethodsRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EvaluationMethodDto>> GetAll()
    {
        return await _context.EvaluationMethods
            .AsNoTracking()
            .ProjectTo<EvaluationMethodDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
