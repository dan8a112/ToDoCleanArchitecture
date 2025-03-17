using Application.DTOs.Users;
using Application.Interfaces.User;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserResponseDTO { Id = u.Id, Name = u.Name });
    }

    public async Task<UserResponseDTO?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user is null ? null : new UserResponseDTO { Id = user.Id, Name = user.Name };
    }

    public async Task<UserResponseDTO> CreateAsync(UserRequestDTO dto)
    {
        var user = new User{Name = dto.Name, Email = dto.Email, Password = dto.Password};
        await _userRepository.AddAsync(user);
        return new UserResponseDTO { Id = user.Id, Name = user.Name , Email = dto.Email};
    }

    public async Task<bool> UpdateAsync(int id, UserRequestDTO dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user is null)
            return false;

        user.Name = dto.Name;

        return await _userRepository.UpdateAsync(user);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}