namespace Application.Interfaces.User;

public interface IUserRepository
{ 
    Task<IEnumerable<Domain.Entities.User>> GetAllAsync();
    Task<Domain.Entities.User?> GetByIdAsync(int id);
    Task AddAsync(Domain.Entities.User user);
    
    Task<bool> UpdateAsync(Domain.Entities.User user);
    Task<bool> DeleteAsync(int id);
}