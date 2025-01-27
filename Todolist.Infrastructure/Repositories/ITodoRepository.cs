using Todolist.Domain.Entities;

namespace Todolist.Infrastructure.Repositories;

public interface ITodoRepository
{
    Task<Todo> CreateAsync(Todo todo);
    Task<Todo> UpdateAsync(Todo todo);
    Task DeleteByIdAsync(int id);
}