using System.ComponentModel.DataAnnotations;

namespace MyToDo.API.Models.Domain;
public class TaskItem
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    public DateTime? DueDate { get; set; }

    public Guid? CategoryId { get; set; }
    public Category Category { get; set; }
}

public enum TaskStatus
{
    Pending,
    Completed,
    Canceled
}

public enum TaskPriority
{
    Low,
    Medium,
    High
}