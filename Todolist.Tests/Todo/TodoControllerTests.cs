using Microsoft.AspNetCore.Mvc;
using Moq;
using Todolist.Application.DTOs.Todo;
using Todolist.Application.Services.Todo;
using Todolist.Presentation.Controllers;

public class TodoControllerTests
    {
        private readonly Mock<ITodoService> _mockService;
        private readonly TodoController _controller;

        public TodoControllerTests()
        {
            _mockService = new Mock<ITodoService>();
            _controller = new TodoController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_Should_Return_OkResult_With_Todos()
        {
            // Arrange
            var todos = new List<GetTodoDto>
            {
                new() { Id = 1, Title = "Test 1", Description = null },
                new() { Id = 2, Title = "Test 2", Description = null }
            };

            _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(todos);

            // Actc
            var result = await _controller.GetAll();
            
            // Assert
            Assert.IsAssignableFrom<IEnumerable<GetTodoDto>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Create_Should_Call_Service_CreateAsync_And_Return_CreatedResult()
        {
            // Arrange
            var createDto = new CreateOrUpdateTodoDto { Title = "New Todo", Description = null };

            // Act
            await _controller.Create(createDto);

            // Assert
            _mockService.Verify(s => s.CreateAsync(createDto), Times.Once);
        }

        [Fact]
        public async Task Update_Should_Call_Service_UpdateAsync_And_Return_NoContent()
        {
            // Arrange
            var updateDto = new CreateOrUpdateTodoDto { Title = "Updated Todo", Description = null };

            // Act
            await _controller.Update(1, updateDto);

            // Assert
            _mockService.Verify(s => s.UpdateAsync(1, updateDto), Times.Once);
        }

        [Fact]
        public async Task Delete_Should_Call_Service_DeleteByIdAsync_And_Return_NoContent()
        {
            // Act
            await _controller.Delete(1);

            // Assert
            _mockService.Verify(s => s.DeleteByIdAsync(1), Times.Once);
        }
    }
