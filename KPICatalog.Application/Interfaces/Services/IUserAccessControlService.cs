namespace KPICatalog.Application.Interfaces.Services;

public interface IUserAccessControlService
{
    Task<bool> HasAccess(string login);
}
