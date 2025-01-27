using Microsoft.AspNetCore.Mvc;
using Todolist.Application.DTOs.Todo;
using Todolist.Application.Services.Todo;

namespace Todolist.Presentation.Controllers;

[ApiController]
[Route("todos")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<GetTodoDto>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpPost("create")]
    public async Task Create([FromBody] CreateOrUpdateTodoDto dto)
    {
        await _service.CreateAsync(dto);
    }
    
    [HttpPut("update/{id}")]
    public async Task Update([FromRoute] int id, [FromBody] CreateOrUpdateTodoDto dto)
    {
        await _service.UpdateAsync(id, dto);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await _service.DeleteByIdAsync(id);
    }
}