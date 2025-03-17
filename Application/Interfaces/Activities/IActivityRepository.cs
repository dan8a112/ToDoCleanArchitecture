using Application.DTOs.Activities;
using Domain.AggregateRoots;

namespace Application.Interfaces.Activities
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<IEnumerable<Activity>> GetAllAsyncByUser( int idUser );
        Task<Activity?> GetByIdAsync(int id);
        Task CreateAsync(Activity activity);
        Task<bool> UpdateAsync(Activity activity);
    }
}
