using Todolist.Domain.Entities;

namespace Todolist.Infrastructure.Repositories;

public interface ITodoRepository
{
    Task CreateAsync(Todo todo);
    Task UpdateAsync(Todo todo);
    Task DeleteByIdAsync(int id);
    Task<IEnumerable<Todo>> GetAllAsync();
}