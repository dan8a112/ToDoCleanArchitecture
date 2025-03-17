using Application.DTOs.Activities;
using Domain.AggregateRoots;

namespace Application.Interfaces.Activities
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<IEnumerable<Activity>> GetAllAsyncByUser( int idUser );
        Task<IEnumerable<Activity>> GetAllAsyncByUserAndDate(int idUser, DateTime date);
        Task<Activity?> GetByIdAsync(int id);
        Task CreateAsync(Activity activity);
    }
}
