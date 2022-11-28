using Microsoft.AspNetCore.Mvc;

namespace BubberBreakFast.Controllers;


public class ErrorController : ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        return Problem();
    }
}