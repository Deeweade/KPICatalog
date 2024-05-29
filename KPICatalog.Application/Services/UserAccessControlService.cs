using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Domain.Interfaces.Repositories;

namespace KPICatalog.Application.Services;

public class UserAccessControlService : IUserAccessControlService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserAccessControlService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> HasAccess(string login)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            throw new ArgumentNullException(nameof(login));

        var control = await _unitOfWork.UserAccessControlRepository.GetByLogin(login);

        if (control is null) throw new NotFoundException($"User with login '{login}' was not found!");

        return control.IsAccessGranted;
    }
}
