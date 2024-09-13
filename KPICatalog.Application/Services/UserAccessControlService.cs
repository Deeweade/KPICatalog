using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class UserAccessControlService : IUserAccessControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserAccessControlService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> HasAccess(string login)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            throw new ArgumentNullException(nameof(login));

        var control = await _unitOfWork.UserAccessControlRepository.GetByLogin(login);

        if (control is null) throw new NotFoundException($"User with login '{login}' was not found!");

        return control.IsAccessGranted;
    }

    public async Task<AllowedAccessesView> GetAllowedAccesses(string login)
    {
        ArgumentNullException.ThrowIfNull(login);

        var employee = await _unitOfWork.EmployeeRepository.GetByLogin(login);

        if (employee is null) throw new NotFoundException($"Employee with login '{login}' was not found!");

        var roles = await _unitOfWork.EmployeeRolesRepository.GetByQuery(new EmployeeRolesQueryDto
        {
             EmployeeIds = new List<int> { employee.Id },
        }, x => x.Role);

        var rolesIds = roles.Select(x => x.Id).Distinct().ToList();

        var actions = await _unitOfWork.RoleAllowedActionsRepository.GetByQuery(new RoleAllowedActionQueryDto
        {
             RolesIds = rolesIds
        }, x => x.Action);

        return new AllowedAccessesView
        {
            Actions = _mapper.Map<List<ActionView>>(actions),
            Roles = _mapper.Map<List<RoleView>>(roles)
        };
    }
}
