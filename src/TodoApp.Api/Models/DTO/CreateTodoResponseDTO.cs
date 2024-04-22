namespace TodoApp.Api.Models.DTO;

public class CreateTodoResponseDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public bool Expired { get; set; } = false;
    public DateTime DueTime { get; set; } = DateTime.Now;
}
