using Domain.AggregateRoots;
using Domain.Common;

namespace Domain.Entities;

public class Task: Entity
{
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    
    public int ActivityId { get; set; }
    public Activity? Activity { get; set; }
}