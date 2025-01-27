namespace Todolist.Application.DTOs.Todo;

public class GetTodoDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    
    public static GetTodoDto FromEntity(Domain.Entities.Todo todo)
    {
        return new GetTodoDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description
        };
    }
}