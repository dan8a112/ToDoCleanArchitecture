using Application.DTOs.Tasks;

namespace Application.Interfaces.Tasks;

public interface ITaskService
{
    public Task<TaskResponseDTO?> GetByIdAsync(int id);
    public Task<IEnumerable<TaskResponseDTO>?> GetAllByActivityAsync(int activityId);
    public Task<TaskResponseDTO> CreateAsync(TaskRequestDTO dto);
    
    public Task<bool> CompleteTaskAsync(int id);


}