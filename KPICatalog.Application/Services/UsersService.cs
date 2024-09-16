using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Application.Models.Views;
using KPICatalog.Domain.Dtos.Filters;
using AutoMapper;

namespace KPICatalog.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsersService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<EmployeeView>> GetByRoleId(int roleId)
    {
        var employeeIds = await _unitOfWork.EmployeeRolesRepository.GetByQuery(new EmployeeRolesQueryDto
        {
            RoleIds = new List<int>{ roleId }
        }, x => x.EmployeeId);

        var employees = await _unitOfWork.EmployeeRepository.GetByIds(employeeIds);

        return _mapper.Map<List<EmployeeView>>(employees);
    }

    public async Task<List<EmployeeView>> GetByActionId(int actionId)
    {
        var roleIds = await _unitOfWork.RoleAllowedActionsRepository.GetByQuery(new RoleAllowedActionQueryDto
        {
            ActionsIds = new List<int>{ actionId }
        }, x => x.RoleId);

        var employeeIds = await _unitOfWork.EmployeeRolesRepository.GetByQuery(new EmployeeRolesQueryDto
        {
            RoleIds = roleIds
        }, x => x.EmployeeId);

        var employees = await _unitOfWork.EmployeeRepository.GetByIds(employeeIds);

        return _mapper.Map<List<EmployeeView>>(employees);
    }
}
