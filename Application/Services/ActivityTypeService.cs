using Application.DTOs.ActivityTypes;
using Application.Interfaces.ActivityType;
using Domain.Entities;

namespace Application.Services;

public class ActivityTypeService : IActivityTypeService
{
    private readonly IActivityTypeRepository _activityTypeRepository;
    
    public ActivityTypeService(IActivityTypeRepository activityTypeRepository)
    {
        _activityTypeRepository = activityTypeRepository;
    }
    
    public async Task<IEnumerable<ActivityTypeResponseDTO>> GetAllAsync()
    {
        var activityTypes = await _activityTypeRepository.GetAllAsync();
        return activityTypes.Select(
            at => new ActivityTypeResponseDTO { Id = at.Id, Name = at.Name, Active = at.Active });
    }

    public async Task<ActivityTypeResponseDTO?> GetByIdAsync(int id)
    {
        var activityType = await _activityTypeRepository.GetByIdAsync(id);
        return activityType is null
            ? null
            : new ActivityTypeResponseDTO
                { Id = activityType.Id, Name = activityType.Name, Active = activityType.Active };
    }

    public async Task<ActivityTypeResponseDTO> CreateAsync(ActivityTypeRequestDTO dto)
    {
        var activityType = new ActivityType(dto.Name);
        await _activityTypeRepository.AddAsync(activityType);
        return new ActivityTypeResponseDTO
            { Id = activityType.Id, Name = activityType.Name, Active = activityType.Active };
    }

    public async Task<bool> UpdateAsync(int id, ActivityTypeRequestDTO dto)
    {
        var activityType = await _activityTypeRepository.GetByIdAsync(id);

        if (activityType is null) return false;

        activityType.Name = dto.Name;
        activityType.Active = dto.Active;

        return await _activityTypeRepository.UpdateAsync(activityType);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _activityTypeRepository.DeleteAsync(id);
    }
}