using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IUsersService
{
    Task<List<EmployeeView>> GetByRoleId(int roleId);
    Task<List<EmployeeView>> GetByActionId(int actionId);
}
