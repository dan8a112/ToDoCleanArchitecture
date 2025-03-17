namespace Application.DTOs.Tasks;

public class TaskResponseDTO
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    
    public int ActivityId { get; set; }
}