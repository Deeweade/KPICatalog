namespace KPICatalog.Domain;

public interface IUserAccessControlRepository
{
    Task<UserAccessControl?> GetByLogin(string login);
}
