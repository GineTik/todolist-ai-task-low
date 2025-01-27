using Todolist.Application.DTOs.Todo;
using Todolist.Infrastructure.Repositories;

namespace Todolist.Application.Services.Todo;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateOrUpdateTodoDto todo)
    {
        await _repository.CreateAsync(todo.ToEntity());
    }

    public async Task UpdateAsync(int id, CreateOrUpdateTodoDto todo)
    {
        var entity = todo.ToEntity();
        entity.Id = id;
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<GetTodoDto>> GetAllAsync()
    {
        var todos = await _repository.GetAllAsync();
        return todos.Select(GetTodoDto.FromEntity);
    }
}