using Application.DTOs.User;

namespace Application.Interfaces.User;

public interface IUserService
{
    Task<IEnumerable<UserResponseDTO>> GetAllAsync();
    Task<UserResponseDTO?> GetByIdAsync(int id);
    Task<UserResponseDTO> CreateAsync(UserRequestDTO user);
    Task<bool> UpdateAsync(int id, UserRequestDTO user);
    Task<bool> DeleteAsync(int id);
}