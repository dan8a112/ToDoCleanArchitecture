namespace Application.Interfaces.Tasks;

public interface ITaskRepository
{
    Task<IEnumerable<Domain.Entities.Task>> GetAllAsync();
    Task<Domain.Entities.Task?> GetByIdAsync(int id);
    Task AddAsync(Domain.Entities.Task task);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(Domain.Entities.Task task);
}