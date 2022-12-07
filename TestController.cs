using Microsoft.AspNetCore.Mvc;

namespace console_api;

[Route("/")]
public class TestController : ControllerBase
{
    
    [HttpGet]
    public ActionResult<string> Get()
    {
        return "hello";
    }
}