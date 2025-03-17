using Application.Interfaces.Activities;
using Domain.AggregateRoots;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ActivityRepository: IActivityRepository
    {
        private readonly BackendDbContext _context;

        public ActivityRepository(BackendDbContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {

            return await _context.Activities.ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllAsyncByUser( int idUser )
        {

            return await _context.Activities
                                 .Where(a => a.UserId == idUser)
                                 .Include(a => a.Tasks)
                                 .Include(a => a.ActivityType)
                                 .Include(a => a.User)
                                 .OrderByDescending(a => a.CreationDate)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllAsyncByUserAndDate(int idUser, DateTime date)
        {

            return await _context.Activities
                                 .Where(a => a.UserId == idUser)
                                 .Include(a => a.Tasks)
                                 .Include(a => a.ActivityType)
                                 .Include(a => a.User)
                                 .OrderByDescending(a => a.CreationDate)
                                 .ToListAsync();
        }

        public async Task<Activity?> GetByIdAsync(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public Task CreateAsync(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
