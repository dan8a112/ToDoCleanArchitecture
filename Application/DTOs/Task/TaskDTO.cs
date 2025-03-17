using Domain.AggregateRoots;

namespace Application.DTOs.Task;

public class TaskDTO
{
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    
    public int ActivityId { get; set; }
    public Activity? Activity { get; set; }
}