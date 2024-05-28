using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KPICatalog.Application;

namespace KPICatalog.API;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]
public class UserAccessController : ControllerBase
{
    private readonly IUserAccessControlService _service;

    public UserAccessController(IUserAccessControlService service)
    {
        _service = service;
    }

    [HttpGet("{login}")]
    public async Task<bool> HasAccess(string login)
    {
        return await _service.HasAccess(login);        
    }
}
