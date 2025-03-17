using Application.DTOs.Activities;
using Application.Interfaces.Activities;
using Domain.AggregateRoots;
using Domain.Entities;

namespace Application.Services
{
    public class ActivityService: IActivityService
    {
        private IActivityRepository _repository;

        public ActivityService(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActivityResponseDTO> CreateAsync(ActivityRequestDTO dto)
        {
            var activity = new Activity
            {
                CreationDate = DateTime.UtcNow,
                EndDate = dto.EndDate,
                Description = dto.Description,
                Completed = false,
                UserId = dto.UserId,
                ActivityTypeId = dto.ActivityTypeId,
                Tasks = new List<Domain.Entities.Task>()
            };

            await _repository.CreateAsync(activity);
            
            return new ActivityResponseDTO{
                CreationDate = activity.CreationDate,
                EndDate = activity.EndDate,
                Description = activity.Description,
                Completed = activity.Completed,
                UserId = activity.UserId,
                ActivityTypeId = activity.ActivityTypeId,
                Tasks = activity.Tasks
            };
        }



        public async Task<IEnumerable<ActivityResponseDTO>?> GetAllAsync()
        {
            var activities = await _repository.GetAllAsync();
            return null;
        }
    }
}
