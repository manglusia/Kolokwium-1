using Microsoft.AspNetCore.Mvc;

namespace WebApplicationKolos1.Controllers;


[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{

    [HttpGet("{id}/authors")]
    public async Task<IActionResult> GetBookAuthors(int id)
    {
        
        return Ok();
    }
}