namespace WebApplicationKolos1.Models.DTOs;

public class AuthorDTO
{
    public int AuthorId { set; get; }
    public string FirstName { set; get; } = string.Empty;
    public string LastName { set; get; } = string.Empty;
}

public class BookDTO
{
    public int BookId { set; get; }
    public string Title { set; get; } = string.Empty;
    public List<AuthorDTO> AuthorOfTheBook { set; get; } = null!;
}