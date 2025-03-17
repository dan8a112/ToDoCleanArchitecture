namespace Application.Interfaces.ActivityType;

public interface IActivityTypeRepository
{
    Task<IEnumerable<Domain.Entities.ActivityType>> GetAllAsync();
    Task<Domain.Entities.ActivityType?> GetByIdAsync(int id);
    Task AddAsync(Domain.Entities.ActivityType activity);
    Task<bool> UpdateAsync(Domain.Entities.ActivityType activity);
    Task<bool> DeleteAsync(int id);
}