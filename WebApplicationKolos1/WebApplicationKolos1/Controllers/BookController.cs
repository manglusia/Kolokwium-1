using Microsoft.AspNetCore.Mvc;
using WebApplicationKolos1.Repositories;

namespace WebApplicationKolos1.Controllers;


[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet("{id}/authors")]
    public async Task<IActionResult> GetBookAuthors(int id)
    {
        var book = await _bookRepository.GetBookAuthors(id);
        return Ok(book);
    }
}