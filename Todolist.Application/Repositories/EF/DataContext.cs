using Microsoft.EntityFrameworkCore;
using Todolist.Domain.Entities;

namespace Todolist.Application.Repositories.EF;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }
}