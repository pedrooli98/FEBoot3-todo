using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Services.Interfaces;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("api/v1/todo")]
public class TodoAppController(ITodoInterface todo) : ControllerBase
{
    
}   
