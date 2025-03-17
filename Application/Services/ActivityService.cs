using Application.DTOs.Activities;
using Application.Interfaces.Activities;

namespace Application.Services
{
    public class ActivityService: IActivityService
    {
        private IActivityRepository? _repository;

        public ActivityService(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ActivityResponseDTO>> GetAllAsync()
        {
            var activities = await _repository.GetAllAsync();
            return null;
        }
    }
}
