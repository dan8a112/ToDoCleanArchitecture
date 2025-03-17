using Application.DTOs.Activities;
using Application.DTOs.Users;
using Application.DTOs.ActivityTypes;
using Application.DTOs.Tasks;
using Application.Interfaces.Activities;
using Domain.AggregateRoots;
using TaskEntity =  Domain.Entities.Task;
using Application.Interfaces.Tasks;
using System.Diagnostics;
using Activity = Domain.AggregateRoots.Activity;
using Application.Interfaces.User;

namespace Application.Services
{
    public class ActivityService: IActivityService
    {
        private readonly IActivityRepository _repository;
        private readonly IUserRepository _userRepository;

        public ActivityService(IActivityRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
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
                Tasks = new List<TaskEntity>()
            };

            await _repository.CreateAsync(activity);
            
            return new ActivityResponseDTO{
                CreationDate = activity.CreationDate,
                EndDate = activity.EndDate,
                Description = activity.Description,
                Completed = activity.Completed,
                UserId = activity.UserId,
                ActivityTypeId = activity.ActivityTypeId,
                Tasks = activity.Tasks.Select( a => new TaskResponseDTO
                {
                    Id = a.Id,
                    Description = a.Description,
                    Completed = a.Completed,
                    StartDate = a.StartDate,
                    FinishDate = a.FinishDate,
                    ActivityId = a.ActivityId
                }).ToList()
            };
        }

        public async Task<IEnumerable<ActivityResponseDTO>> GetAllAsyncByUser( int idUser )
        {
            var user = await _userRepository.GetByIdAsync(idUser);
            if (user is null) return null;

            //Se obtienen las actividades que coinciden con userId
            var activities = (await _repository.GetAllAsync()).Where(u => u.UserId == idUser);

            return activities.Select(a => new ActivityResponseDTO
            {
                Id = a.Id,
                CreationDate = a.CreationDate,
                EndDate = a.EndDate,
                Description = a.Description,
                Completed = a.Completed,

                UserId = a.UserId,
                UserResponseDTO = a.User != null ? new UserResponseDTO
                {
                    Id = a.User.Id,
                    Name = a.User.Name,
                    Email = a.User.Email
                } : null,

                ActivityTypeId = a.ActivityTypeId,
                ActivityTypeResponseDTO = a.ActivityType != null ? new ActivityTypeResponseDTO
                {
                    Id = a.ActivityType.Id,
                    Name = a.ActivityType.Name,
                    Active = a.ActivityType.Active
                } : null,

                Tasks = a.Tasks?.Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    Description = t.Description,
                    Completed = t.Completed,
                    StartDate = t.StartDate,
                    FinishDate = t.FinishDate,
                    ActivityId = t.ActivityId
                }).ToList() ?? new List<TaskResponseDTO>()
            });

        }

        public async Task<IEnumerable<ActivityResponseDTO>> GetAllAsyncByUserAndDate(int idUser, DateTime date)
        {
            var user = await _userRepository.GetByIdAsync(idUser);
            if (user is null) return null;

            //Se obtienen las actividades que coinciden con userId
            var activities = (await _repository.GetAllAsync()).Where(a => ( a.UserId == idUser && a.CreationDate == date));

            return activities.Select(a => new ActivityResponseDTO
            {
                Id = a.Id,
                CreationDate = a.CreationDate,
                EndDate = a.EndDate,
                Description = a.Description,
                Completed = a.Completed,

                UserId = a.UserId,
                UserResponseDTO = a.User != null ? new UserResponseDTO
                {
                    Id = a.User.Id,
                    Name = a.User.Name,
                    Email = a.User.Email
                } : null,

                ActivityTypeId = a.ActivityTypeId,
                ActivityTypeResponseDTO = a.ActivityType != null ? new ActivityTypeResponseDTO
                {
                    Id = a.ActivityType.Id,
                    Name = a.ActivityType.Name,
                    Active = a.ActivityType.Active
                } : null,

                Tasks = a.Tasks?.Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    Description = t.Description,
                    Completed = t.Completed,
                    StartDate = t.StartDate,
                    FinishDate = t.FinishDate,
                    ActivityId = t.ActivityId
                }).ToList() ?? new List<TaskResponseDTO>()
            });
        }
    }
}
