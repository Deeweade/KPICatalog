using KPICatalog.Application.Interfaces.Services;
using KPICatalog.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet("byRole/{roleId}")]
        public async Task<List<EmployeeView>> GetByRoleId(int roleId)
        {
            return await _service.GetByRoleId(roleId);
        }

        [HttpGet("byAction/{actionId}")]
        public async Task<List<EmployeeView>> GetByActionId(int actionId)
        {
            return await _service.GetByActionId(actionId);
        }
    }
}
