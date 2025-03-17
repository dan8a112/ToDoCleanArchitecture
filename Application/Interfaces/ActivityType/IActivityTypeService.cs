using Application.DTOs.ActivityTypes;

namespace Application.Interfaces.ActivityType;

public interface IActivityTypeService
{
    Task<IEnumerable<ActivityTypeResponseDTO>> GetAllAsync();
    Task<ActivityTypeResponseDTO?> GetByIdAsync(int id);
    Task<ActivityTypeResponseDTO> CreateAsync(ActivityTypeRequestDTO dto);
    Task<bool> UpdateAsync(int id, ActivityTypeRequestDTO dto);
    Task<bool> DeleteAsync(int id);
}