using Microsoft.AspNetCore.Mvc;

namespace WebApplicationKolos1.Controllers;


[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        
    }
}