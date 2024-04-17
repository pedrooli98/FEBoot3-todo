using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Models;

namespace TodoApp.Api.Db;

public class TodoContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }
}
