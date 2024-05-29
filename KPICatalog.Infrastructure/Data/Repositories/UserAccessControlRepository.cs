using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace KPICatalog.Infrastructure.Data.Repositories;

internal class UserAccessControlRepository : IUserAccessControlRepository
{
    private readonly KPICatalogDbContext _context;
    private readonly IMapper _mapper;

    public UserAccessControlRepository(KPICatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserAccessControlDto?> GetByLogin(string login)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            throw new ArgumentNullException(nameof(login));

        var control = await _context.UserAccessControls
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Login.Equals(login));

        return _mapper.Map<UserAccessControlDto>(control);
    }
}
