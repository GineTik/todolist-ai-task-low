using Microsoft.EntityFrameworkCore;
using Todolist.Application.Repositories;
using Todolist.Application.Repositories.EF;

namespace Todolist.Tests.Todo;

public class TodoRepositoryTests
{
    private readonly DbContextOptions<DataContext> _options;

    public TodoRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique DB for each test
            .Options;
    }

    [Fact]
    public async Task CreateAsync_Should_Add_Todo_To_Database()
    {
        // Arrange
        await using var context = new DataContext(_options);
        var repository = new TodoRepository(context);
        
        var todo = new Domain.Entities.Todo { Title = "Test Todo", Description = null};

        // Act
        await repository.CreateAsync(todo);
        
        // Assert
        var result = await context.Todos.FirstOrDefaultAsync();
        Assert.NotNull(result);
        Assert.Equal("Test Todo", result.Title);
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Todo_In_Database()
    {
        // Arrange
        await using var context = new DataContext(_options);
        var repository = new TodoRepository(context);
        
        var todo = new Domain.Entities.Todo { Title = "Initial Todo", Description = null };
        context.Todos.Add(todo);
        await context.SaveChangesAsync();

        // Act
        todo.Title = "Updated Todo";
        await repository.UpdateAsync(todo);
        
        // Assert
        var result = await context.Todos.FirstOrDefaultAsync();
        Assert.NotNull(result);
        Assert.Equal("Updated Todo", result.Title);
    }

    [Fact]
    public async Task DeleteByIdAsync_Should_Throw_Db_Exception()
    {
        // Arrange
        await using var context = new DataContext(_options);
        var repository = new TodoRepository(context);

        // Act
        var act = async () => await repository.DeleteByIdAsync(1000);

        // Assert
        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(act);
    }
}
