using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Data.Contexts;
using KPICatalog.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Repositories;

internal class UserAccessControlRepository : IUserAccessControlRepository
{
    private readonly KPICatalogDbContext _context;

    public UserAccessControlRepository(KPICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<UserAccessControl?> GetByLogin(string login)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            throw new ArgumentNullException(nameof(login));

        return await _context.UserAccessControls
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Login.Equals(login));
    }
}
