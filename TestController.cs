using Microsoft.AspNetCore.Mvc;

namespace ConsoleApi;

[Route("/")]
public class TestController : ControllerBase
{
    
    [HttpGet]
    public ActionResult<string> Get()
    {
        return "hello";
    }
}