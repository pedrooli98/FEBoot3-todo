namespace TodoApp.Api.Models;

public class TodoItem
{
    public Guid Id { get; set; } // Auto-incrementing primary key
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public bool Expired { get; set; } = false;
    public DateTime DueTime { get; set; } = DateTime.Now;
}
