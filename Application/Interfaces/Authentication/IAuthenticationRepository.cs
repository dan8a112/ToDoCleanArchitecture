using Application.DTOs.Users;

namespace Application.Interfaces;

public interface IAuthenticationRepository
{ 
    Task<Domain.Entities.User?> LoginAsync(UserLoginDTO user);
}
