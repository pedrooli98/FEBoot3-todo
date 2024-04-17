using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Db;
using TodoApp.Api.Models;
using TodoApp.Api.Services.Interfaces;

namespace TodoApp.Api.Services;

public class TodoService(TodoContext context) : ITodoInterface
{
    public async Task<TodoItem> Create(TodoItem t)
    {
        context.TodoItems.Add(t);
        await context.SaveChangesAsync();
        return t;
    }

    public async Task<bool> Delete(Guid id)
    {
        var foundTodo = await context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

        if (foundTodo is null)
        {
            return false;
        }
        context.TodoItems.Remove(foundTodo);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<TodoItem?> Get(Guid id)
    {
        var foundTodo = await context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
        return foundTodo;
    }

    public async Task<TodoItem> Update(Guid id, TodoItem t)
    {
        var foundTodo = await context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
        if (foundTodo is null)
            throw new Exception("Todo not found");
        
        foundTodo.Title = t.Title;
        foundTodo.Description = t.Description;
        foundTodo.IsCompleted = t.IsCompleted;

        context.TodoItems.Update(foundTodo);

        await context.SaveChangesAsync();
        
        return foundTodo;
    }
}
