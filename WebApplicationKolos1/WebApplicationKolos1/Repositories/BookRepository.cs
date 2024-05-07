using WebApplicationKolos1.Models.DTOs;
using Microsoft.Data.SqlClient;

namespace WebApplicationKolos1.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IConfiguration _configuration;

    public BookRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<BookDTO> GetBookAuthors(int id)
    {
        var zapytanie = @"
SELECT a.PK as AuthorId, a.first_name as FirstName, a.last_name as LastName, b.PK as BookId, b.title as Title 
FROM authors a 
INNER JOIN books_authors ba ON ba.FK_author=a.PK
INNER JOIN books b ON b.PK = ba.FK_book
WHERE b.PK = @ID";

        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        await using SqlCommand command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = zapytanie;
        command.Parameters.AddWithValue("@ID", id);

        await connection.OpenAsync();

        var reader = await command.ExecuteReaderAsync();

        var AuthorIdOrdinal = reader.GetOrdinal("AuthorId");
        var BookIdOridnal = reader.GetOrdinal("BookId");
        var BookTitleOrdinal = reader.GetOrdinal("Title");
        var AuthorLastNameOrdinal = reader.GetOrdinal("LastName");
        var AuthorFirstName = reader.GetOrdinal("FirstName");

        BookDTO bookDto = null;

        while (await reader.ReadAsync())
        {
            if (bookDto is not null)
            {
                bookDto.AuthorOfTheBook.Add(new AuthorDTO()
                {
                    AuthorId = reader.GetInt32(AuthorIdOrdinal),
                    FirstName = reader.GetString(AuthorFirstName),
                    LastName = reader.GetString(AuthorLastNameOrdinal)
                });   
            }
            else
            {
                bookDto = new BookDTO()
                {
                    BookId = reader.GetInt32(BookIdOridnal),
                    Title = reader.GetString(BookTitleOrdinal),
                    AuthorOfTheBook = new List<AuthorDTO>()
                    {
                        new AuthorDTO()
                        {
                            AuthorId = reader.GetInt32(AuthorIdOrdinal),
                            FirstName = reader.GetString(AuthorFirstName),
                            LastName = reader.GetString(AuthorLastNameOrdinal)
                        }
                    }
                };
            }
        }

        if (bookDto is null) throw new Exception();
        
        return bookDto;
    }
    
}