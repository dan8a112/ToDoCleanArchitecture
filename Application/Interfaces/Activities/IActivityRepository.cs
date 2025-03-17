using Application.DTOs.Activities;
using Domain.AggregateRoots;

namespace Application.Interfaces.Activities
{
    public interface IActivityRepository
    {
        ///<summary>
        ///Para obtener todas las actividades que tiene registradas un usuario.
        ///</summary>>
        Task<IEnumerable<Activity>> GetAllAsync();

        Task CreateAsync(Activity activity);
    }
}
