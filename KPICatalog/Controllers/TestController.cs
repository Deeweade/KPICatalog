using Microsoft.AspNetCore.Mvc;

namespace KPICatalog;

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
