namespace TodoApp.Api.Models;

public class TodoItem
{
    public int Id { get; set; } // Auto-incrementing primary key
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
