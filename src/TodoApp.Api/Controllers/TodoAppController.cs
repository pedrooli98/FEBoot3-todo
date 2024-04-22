using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Services.Interfaces;
using TodoApp.Api.Models.DTO;
using TodoApp.Api.Models;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("api/v1/todo")]
public class TodoAppController(ITodoInterface todo) : ControllerBase
{
    /// </summary>
    /// <param name="todoItem">The item to be created</param>
    /// <returns>The created item</returns>
    /// <response code="201">The item was created successfully</response>
    /// <response code="400">The item is null</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateTodoResponseDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateTodoResponseDTO>> Create([FromBody] TodoDTO todoItem)
    {
        var createdItem = await todo.Create(new TodoItem { Title = todoItem.Title, Description = todoItem.Description });

        if (createdItem is null)
            return BadRequest();

        var response = new CreateTodoResponseDTO
        {
            Title = createdItem.Title,
            Description = createdItem.Description,
            IsCompleted = createdItem.IsCompleted,
            Expired = createdItem.Expired,
            DueTime = createdItem.DueTime

        };

        return CreatedAtAction(nameof(Create), new { id = createdItem.Id }, response);
    }

    /// <summary>
    /// Deletes a Todo item by Id.
    /// </summary>
    /// <param name="id">The item id</param>
    /// <returns>Nothing</returns>
    /// <response code="204">The item was deleted successfully</response>
    /// <response code="404">The item does not exists</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await todo.Delete(id);

        if (result)
            return NoContent();

        return NotFound();
    }
}   
