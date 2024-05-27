using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "RequireAuthenticatedUser")]
    public string Index()
    {
        return "Hello world!";
    }
}
