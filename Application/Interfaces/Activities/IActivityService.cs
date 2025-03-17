using Application.DTOs.Activities;

namespace Application.Interfaces.Activities
{
    public interface IActivityService
    {
        ///<summary>
        ///Para obtener todas las actividades que tiene registradas un usuario.
        ///</summary>>
        Task<IEnumerable<ActivityResponseDTO>> GetAllAsync();
    }
}
