using KPICatalog.Domain.Models.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IUserAccessControlRepository
{
    Task<UserAccessControl?> GetByLogin(string login);
}
