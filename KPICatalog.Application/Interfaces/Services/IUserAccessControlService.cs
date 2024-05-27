namespace KPICatalog.Application;

public interface IUserAccessControlService
{
    Task<bool> HasAccess(string login);
}
