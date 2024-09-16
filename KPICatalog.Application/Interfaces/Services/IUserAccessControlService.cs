using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IUserAccessControlService
{
    Task<bool> HasAccess(string login);
    Task<AllowedAccessesView> GetAllowedAccesses(string login);
}
