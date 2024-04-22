namespace TodoApp.Api.Models.DTO;

public class TodoDTO
{
    public Guid Id { get; set; } // Auto-incrementing primary key
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueTime { get; set; } = DateTime.Now;
}
