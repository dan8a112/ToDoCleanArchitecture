using Application.DTOs.Activities;

namespace Application.Interfaces.Activities
{
    public interface IActivityService
    {
        Task<ActivityResponseDTO> CreateAsync(ActivityRequestDTO dto);
        Task<IEnumerable<ActivityResponseDTO>> GetAllAsyncByUser(int idUser);
        Task<IEnumerable<ActivityResponseDTO>> GetAllAsyncByUserAndDate(int idUser, DateTime date);
    }

}
