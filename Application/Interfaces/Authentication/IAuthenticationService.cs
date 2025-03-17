using Application.DTOs.Users;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string?> LoginAsync(UserLoginDTO user);    
    }
}