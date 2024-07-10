using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IUserAccessControlRepository
{
    Task<UserAccessControlDto> GetByLogin(string login);
}
