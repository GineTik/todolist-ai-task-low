using Microsoft.EntityFrameworkCore;
using Moq;
using Todolist.Application.DTOs.Todo;
using Todolist.Application.Services.Todo;
using Todolist.Domain.Entities;
using Todolist.Infrastructure.Repositories;

public class TodoServiceTests
{
    private readonly Mock<ITodoRepository> _mockRepository;
    private readonly TodoService _service;

    public TodoServiceTests()
    {
        _mockRepository = new Mock<ITodoRepository>();
        _service = new TodoService(_mockRepository.Object);
    }

    [Fact]
    public async Task CreateAsync_Should_Call_Repository_CreateAsync()
    {
        // Arrange
        var todoDto = new CreateOrUpdateTodoDto { Title = "Test Todo", Description = null };

        // Act
        await _service.CreateAsync(todoDto);

        // Assert
        _mockRepository.Verify(r => r.CreateAsync(It.Is<Todo>(t => t.Title == "Test Todo" && t.Description == null)), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_Should_Call_Repository_UpdateAsync_With_Correct_Id()
    {
        // Arrange
        var todoDto = new CreateOrUpdateTodoDto { Title = "Updated Todo", Description = "Updated description" };

        // Act
        await _service.UpdateAsync(1, todoDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateAsync(It.Is<Todo>(t => t.Id == 1 && t.Title == "Updated Todo" && t.Description == "Updated description")), Times.Once);
    }

    [Fact]
    public async Task DeleteByIdAsync_Should_Call_Repository_DeleteByIdAsync()
    {
        // Act
        await _service.DeleteByIdAsync(1);

        // Assert
        _mockRepository.Verify(r => r.DeleteByIdAsync(1), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_Correct_Data()
    {
        // Arrange
        var todos = new List<Todo>
        {
            new() { Id = 1, Title = "Test 1", Description = null},
            new() { Id = 2, Title = "Test 2", Description = "Some description"}
        };

        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(todos);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, t => t.Id == 1 && t.Title == "Test 1" && t.Description == null);
        Assert.Contains(result, t => t.Id == 2 && t.Title == "Test 2" && t.Description == "Some description");
    }
}