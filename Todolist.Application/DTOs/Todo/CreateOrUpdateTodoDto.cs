using System.ComponentModel.DataAnnotations;

namespace Todolist.Application.DTOs.Todo;

public class CreateOrUpdateTodoDto
{
    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public Domain.Entities.Todo ToEntity()
    {
        return new Domain.Entities.Todo
        {
            Title = Title,
            Description = Description
        };
    }
}