using WebApplicationKolos1.Models.DTOs;

namespace WebApplicationKolos1.Repositories;

public interface IBookRepository
{
    
    Task<BookDTO> GetBookAuthors(int id);
}