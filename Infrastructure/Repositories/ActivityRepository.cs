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
    }
}
