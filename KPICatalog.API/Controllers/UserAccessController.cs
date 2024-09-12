using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers;

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

    [HttpGet("allowedAccesses/{login}")]
    public async Task<AllowedAccessesView> GetAllowedAccesses(string login)
    {
        return await _service.GetAllowedAccesses(login);        
    }
}
