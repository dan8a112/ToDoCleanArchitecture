using Application.Interfaces.Tasks;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly BackendDbContext _context;

    public TaskRepository(BackendDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Task>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async System.Threading.Tasks.Task AddAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task is null) return false;

        _context.Tasks.Remove(task);
        return await _context.SaveChangesAsync() > 0;
    }
}