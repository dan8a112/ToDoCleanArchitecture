using Application.DTOs.Tasks;
using Application.Interfaces.Activities;
using Application.Interfaces.Tasks;
using Task = Domain.Entities.Task;

namespace Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IActivityRepository _activityRepository;

    public TaskService(ITaskRepository taskRepository, IActivityRepository activityRepository)
    {
        _taskRepository = taskRepository;
        _activityRepository = activityRepository;
    }

    public async Task<TaskResponseDTO?> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task is null
            ? null
            : new TaskResponseDTO
            {
                Id = task.Id,
                Description = task.Description,
                ActivityId = task.ActivityId,
                Completed = task.Completed,
                StartDate = task.StartDate,
                FinishDate = task.FinishDate
            };
    }

    public async Task<IEnumerable<TaskResponseDTO>?> GetAllByActivityAsync(int activityId)
    {
        var activity = await _activityRepository.GetByIdAsync(activityId);
        if (activity is null) return null;

        //Se obtienen las tareas que coinciden con activityId
        var tasks = (await _taskRepository.GetAllAsync()).Where(t => t.ActivityId == activityId);
        
        return tasks.Select(t => new TaskResponseDTO
        {
            Id = t.Id,
            Description = t.Description,
            ActivityId = t.ActivityId,
            Completed = t.Completed,
            StartDate = t.StartDate,
            FinishDate = t.FinishDate
        });
    }

    public async Task<TaskResponseDTO> CreateAsync(TaskRequestDTO dto)
    {
        var task = new Task
        {
            Description = dto.Description,
            ActivityId = dto.ActivityId,
            Completed = dto.Completed,
            StartDate = dto.StartDate,
            FinishDate = dto.FinishDate
        };

        await _taskRepository.AddAsync(task);
        return new TaskResponseDTO {
            Id = task.Id,
            Description = task.Description,
            ActivityId = task.ActivityId,
            Completed = task.Completed,
            StartDate = task.StartDate,
            FinishDate = task.FinishDate
        };
    }
}