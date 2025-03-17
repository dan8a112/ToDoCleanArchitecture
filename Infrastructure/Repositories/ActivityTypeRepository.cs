using Application.Interfaces.ActivityType;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Repositories;

public class ActivityTypeRepository : IActivityTypeRepository
{

    private readonly BackendDbContext _context;

    public ActivityTypeRepository(BackendDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ActivityType>> GetAllAsync()
    {
        return await _context.ActivityTypes.ToListAsync();
    }

    public async Task<ActivityType?> GetByIdAsync(int id)
    {
        return await _context.ActivityTypes.FindAsync(id);
    }

    public async Task AddAsync(ActivityType activity)
    {
        _context.ActivityTypes.Add(activity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(ActivityType activity)
    {
        _context.ActivityTypes.Update(activity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var activityType = await _context.ActivityTypes.FindAsync(id);
        if (activityType is null) return false;
        _context.ActivityTypes.Remove(activityType);
        return await _context.SaveChangesAsync() > 0;
    }
}