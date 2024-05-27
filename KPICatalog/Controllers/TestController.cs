using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KPICatalog;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TestController : Controller
{
    [HttpGet]
    public string Index()
    {
        return "Hello world!";
    }
}
