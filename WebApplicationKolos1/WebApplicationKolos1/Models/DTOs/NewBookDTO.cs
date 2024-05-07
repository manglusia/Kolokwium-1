namespace WebApplicationKolos1.Models.DTOs;

public class NewBookDTO
{
    public int Id { set; get; }
    public string Title { set; get; }
    private List<AuthorDTO> _authorOfTheBook { set; get; } = null!;
}