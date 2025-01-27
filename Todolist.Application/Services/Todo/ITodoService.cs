using Todolist.Application.DTOs;
using Todolist.Application.DTOs.Todo;

namespace Todolist.Application.Services.Todo;

public interface ITodoService
{
    Task CreateAsync(CreateOrUpdateTodoDto todo);
    Task UpdateAsync(int id, CreateOrUpdateTodoDto todo);
    Task DeleteByIdAsync(int id);
    Task<IEnumerable<GetTodoDto>> GetAllAsync();
}