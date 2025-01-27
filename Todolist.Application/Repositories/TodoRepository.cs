using Microsoft.EntityFrameworkCore;
using Todolist.Application.Repositories.EF;
using Todolist.Domain.Entities;
using Todolist.Infrastructure.Repositories;

namespace Todolist.Application.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;

    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Todo todo)
    {
        _context.Todos.Update(todo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        _context.Todos.Remove(new Todo {Id = id});
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        return await _context.Todos.ToListAsync();
    }
}